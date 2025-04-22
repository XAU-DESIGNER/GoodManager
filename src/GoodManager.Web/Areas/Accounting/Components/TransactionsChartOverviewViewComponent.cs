using GoodManager.Application.Extensions;
using GoodManager.Application.Services.Interfaces.Accounting;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.Accounting.Components;

[ViewComponent]
public class TransactionsChartOverviewViewComponent(IAccountingTransactionService accountingTransactionService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await accountingTransactionService.GetOverViewForChartAsync(HttpContext.User.GetUserId());

        if (result.IsFailure) return View();

        return View(result.Value);
    }
}
