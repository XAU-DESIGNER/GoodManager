using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.Interfaces.Common;
using GoodManager.Domain.Models.Common;
using GoodManager.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoodManager.Infrastructure.Persistence.Repositories.Common;

public abstract class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    protected readonly GoodManagerDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected EfRepository(GoodManagerDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<int> CountAsync()
        => await _dbSet.CountAsync();

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        => await _dbSet.CountAsync(predicate);

    public virtual void Delete(TEntity entity) => _dbSet.Remove(entity);


    public void DeleteRange(List<TEntity> entities) => _dbSet.RemoveRange(entities);


    /// <inheritdoc/>
    public async Task ExecuteDeleteRange(Expression<Func<TEntity, bool>> filter) =>
        await _dbSet.Where(filter).ExecuteDeleteAsync();

    public async Task ExecuteDeleteRange()
      => await _dbSet.ExecuteDeleteAsync();


    public void SoftDelete(TEntity entity)
    {
        entity.IsDeleted = true;
        _dbSet.Update(entity);
    }

    /// <inheritdoc />
    public bool SoftDeleteOrRecover(TEntity entity)
    {
        entity.IsDeleted = !entity.IsDeleted;
        _dbSet.Update(entity);
        return entity.IsDeleted;
    }
    /// <inheritdoc/>
    public async Task SoftDeleteAllAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        if (filter is null)
            await _dbSet.ExecuteUpdateAsync(setters => setters.SetProperty(s => s.IsDeleted, true));
        else
            await _dbSet.Where(filter)
                .ExecuteUpdateAsync(setters => setters.SetProperty(s => s.IsDeleted, true));
    }


    public async Task<List<TEntity>> GetAllAsync()
        => await _dbSet.AsNoTrackingWithIdentityResolution().ToListAsync();



    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        => await _dbSet
            .Where(filter)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    public async Task<List<TModel>> GetAllAsync<TModel>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TModel>> mapping)
        => await _dbSet
            .Where(filter)
            .AsNoTrackingWithIdentityResolution()
            .Select(mapping)
            .ToListAsync();

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, params string[] includeProperties)
    {
        var query = _dbSet.AsQueryable();

        query = query.Where(filter);

        foreach (var include in includeProperties)
        {
            query = query.Include(include);
        }

        query = query.AsNoTrackingWithIdentityResolution();
        return await query.ToListAsync();
    }

    public async Task<TEntity?> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, object>>? orderByDesc = null,
        params string[] includeProperties)
    {
        var query = _dbSet.AsQueryable();

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        foreach (var inlcudeProperty in includeProperties)
        {
            query = query.Include(inlcudeProperty);
        }

        if (orderBy is not null)
        {
            query = query.OrderBy(orderBy);
        }

        if (orderByDesc is not null)
        {
            query = query.OrderByDescending(orderByDesc);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<TEntity?> LastOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, object>>? orderByDesc = null,
        params string[] includeProperties)
    {
        var query = _dbSet.AsQueryable();

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        foreach (var inlcudeProperty in includeProperties)
        {
            query = query.Include(inlcudeProperty);
        }

        if (orderBy is not null)
        {
            query = query.OrderBy(orderBy);
        }

        if (orderByDesc is not null)
        {
            query = query.OrderByDescending(orderByDesc);
        }

        return await query.LastOrDefaultAsync();
    }


    public async Task FilterAsync<TModel>(
        BasePaging<TModel> filterModel,
        FilterConditions<TEntity> filterConditions,
        Expression<Func<TEntity, TModel>> mapping,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, object>>? orderByDesc = null,
        params string[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var inlcudeProperty in includeProperties)
        {
            query = query.Include(inlcudeProperty);
        }


        foreach (var filter in filterConditions)
        {
            query = query.Where(filter);
        }


        if (orderBy is not null)
            query = query.OrderBy(orderBy);
        else if (orderByDesc is not null)
            query = query.OrderByDescending(orderByDesc);

        else if (typeof(TEntity).IsAssignableTo(typeof(AuditBaseEntity<TKey>)))
            query = query.OrderByDescending(entity => (entity as AuditBaseEntity<TKey>)!.CreatedDateOnUtc);


        await filterModel.AsPagable(query.AsNoTrackingWithIdentityResolution().Select(mapping));
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, params string[] includeProperties)
    {
        if (id is null) return null;

        var query = _dbSet.AsQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.FirstOrDefaultAsync(entity => entity.Id!.Equals(id));
    }

    public async Task InsertAsync(TEntity entity) => await _dbSet.AddAsync(entity);


    public async Task InsertRangeAsync(List<TEntity> entities) => await _dbSet.AddRangeAsync(entities);


    public void Update(TEntity entity) => _dbSet.Update(entity);


    public void UpdateRange(List<TEntity> entities) => _dbSet.UpdateRange(entities);


    public IQueryable<TEntity> GetQueryable() => _dbSet;


    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) =>
        await _dbSet.AnyAsync(predicate);


    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();


}

public class EfRepository<TEntity>(GoodManagerDbContext context)
    : EfRepository<TEntity, int>(context), IRepository<TEntity>
    where TEntity : BaseEntity<int>;