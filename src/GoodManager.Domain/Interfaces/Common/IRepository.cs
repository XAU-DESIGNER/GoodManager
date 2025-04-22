using GoodManager.Domain.Common.Filter;
using GoodManager.Domain.Models.Common;
using System.Linq.Expressions;

namespace GoodManager.Domain.Interfaces.Common;

public interface IRepository<TEntity, TKey>
     where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
{

    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

    void SoftDelete(TEntity entity);
    /// <summary>
    /// changes the delete state of an entity and update it(uses soft delete)
    /// </summary>
    /// <param name="entity">entity for changing delete state</param>
    /// <returns>a boolean that that indicates the current state of soft delete if it,s true meant the current entity is deleted if it is false it means that the entity current state is changed to recoverd from delete</returns>
    bool SoftDeleteOrRecover(TEntity entity);

    /// <summary>
    /// soft deletes entities based on a condition. if the condition is null soft deletes all the entities in the table.
    /// there is no need to call SaveAsync Method after for saving changes to database because This operation executes immediately against the database,.  
    /// </summary>
    /// <param name="filter">filters the entities to soft delete</param>
    Task SoftDeleteAllAsync(Expression<Func<TEntity, bool>>? filter = null);

    Task<TEntity?> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, object>>? orderByDesc = null,
        params string[] includeProperties);

    Task<TEntity?> LastOrDefaultAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, object>>? orderByDesc = null,
        params string[] includeProperties);


    void Delete(TEntity entity);
    void DeleteRange(List<TEntity> entities);


    /// <summary>
    /// remove rows form the database based on a conditions. no need to call the <see cref="SaveChangesAsync"/> method this method executes automatically into database. 
    /// </summary>
    /// <param name="filter">condition to remove rows form database based on that</param>
    Task ExecuteDeleteRange(Expression<Func<TEntity, bool>> filter);

    /// <summary>
    /// remove rows form the database based on a conditions. no need to call the <see cref="SaveChangesAsync"/> method this method executes automatically into database. 
    /// </summary>
    Task ExecuteDeleteRange();

    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

    Task<List<TModel>> GetAllAsync<TModel>(Expression<Func<TEntity, bool>> filter,
        Expression<Func<TEntity, TModel>> mapping);

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, params string[] includeProperties);

    Task FilterAsync<TModel>(
        BasePaging<TModel> filterModel,
        FilterConditions<TEntity> filterConditions,
        Expression<Func<TEntity, TModel>> mapping,
        Expression<Func<TEntity, object>>? orderBy = null,
        Expression<Func<TEntity, object>>? orderByDesc = null,
        params string[] includeProperties);
    Task<TEntity?> GetByIdAsync(TKey id, params string[] includeProperties);
    Task InsertAsync(TEntity entity);
    Task InsertRangeAsync(List<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(List<TEntity> entities);
    IQueryable<TEntity> GetQueryable();
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task SaveChangesAsync();

}


public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : BaseEntity<int>;
