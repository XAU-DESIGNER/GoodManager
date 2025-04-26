using GoodManager.Application.Extensions;
using GoodManager.Application.Services.Interfaces.Accounting;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.Accounting.Components;

[ViewComponent]
public class LastYearCostsAndIncomeViewComponent (IAccountingTransactionReportService accountingTransactionReportService): ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        int userId = HttpContext.User.GetUserId();
        var result = await accountingTransactionReportService.GetLastYearCostsAndIncomeAsync(userId);

        if (result.IsFailure) return View();

        return View(result.Value);
    }
}