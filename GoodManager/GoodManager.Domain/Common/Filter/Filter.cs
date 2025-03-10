using System.Linq.Expressions;

namespace GoodManager.Domain.Common.Filter;

public class FilterConditions<TEntity> : List<Expression<Func<TEntity, bool>>> { }

public class FilterOrder<TEntity>
{
    public bool IsAscending { get; private set; }
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }

    public FilterOrder(Expression<Func<TEntity, object>> orderBy, bool isAscending)
    {
        IsAscending = isAscending;
        OrderBy = orderBy;
    }
}

public static class Filter
{
    public static FilterOrder<TEntity> OrderBy<TEntity>(Expression<Func<TEntity, object>> orderBy, bool isAscending) 
        => new (orderBy, isAscending);
    
    public static FilterConditions<TEntity> GenerateConditions<TEntity>() => [];
}