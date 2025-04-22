using GoodManager.Domain.Common.Filter;
using Microsoft.EntityFrameworkCore;

namespace GoodManager.Infrastructure.Extensions;

public static class FilterExtensions
{
    public static PagingViewModel GetCurrentPaging<TEntity>(this BasePaging<TEntity> paging) => new()
    {
        Page = paging.CurrentPage,
        EndPage = paging.EndPage,
        StartPage = paging.StartPage
    };

    public static string GetShownEntitiesPagesTitle<TEntity>(this BasePaging<TEntity> paging)
    {
        if (paging.AllEntitiesCount == 0) return $"0 آیتم";

        var startItem = 1;
        var endItem = paging.AllEntitiesCount;

        if (paging.EndPage > 1)
        {
            startItem = (paging.CurrentPage - 1) * paging.TakeEntity + 1;
            endItem = paging.CurrentPage * paging.TakeEntity > paging.AllEntitiesCount ? paging.AllEntitiesCount : paging.CurrentPage * paging.TakeEntity;
        }

        return $"نمایش {startItem} تا {endItem} از {paging.AllEntitiesCount}";

    }

    public static async Task<BasePaging<TEntity>> AsPagable<TEntity>(this BasePaging<TEntity> paging, IQueryable<TEntity> entities)
    {
        var allEntitiesCount = await entities.CountAsync();

        var pageCount = Convert.ToInt32(Math.Ceiling(allEntitiesCount / (double)paging.TakeEntity));

        paging.CurrentPage = paging.CurrentPage > pageCount ? pageCount : paging.CurrentPage;
        if (paging.CurrentPage <= 0) paging.CurrentPage = 1;
        paging.AllEntitiesCount = allEntitiesCount;
        paging.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
        paging.SkipEntity = (paging.CurrentPage - 1) * paging.TakeEntity;
        paging.StartPage = paging.CurrentPage - paging.HowManyShowPageAfterAndBefore <= 0 ? 1 : paging.CurrentPage - paging.HowManyShowPageAfterAndBefore;
        paging.EndPage = paging.CurrentPage + paging.HowManyShowPageAfterAndBefore > pageCount
            ? pageCount
            : paging.CurrentPage + paging.HowManyShowPageAfterAndBefore;
        paging.PageCount = pageCount;
        paging.Entities = await entities.Skip(paging.SkipEntity).Take(paging.TakeEntity).ToListAsync();
        paging.Counter = ((paging.CurrentPage - 1) * paging.TakeEntity) + 1;

        return paging;
    }
}