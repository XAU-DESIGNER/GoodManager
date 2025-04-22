using GoodManager.Application.Extensions;
using GoodManager.Application.Services.Interfaces.Accounting;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.Accounting.Components;

[ViewComponent]
public class LastTransactionsViewComponent(IAccountingTransactionService accountingTransactionService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = HttpContext.User.GetUserId();

        var result = await accountingTransactionService.FilterAsync(new Domain.DTOs.ViewModels.Accounting.Transactions.FilterAccountingTransactionViewModel()
        {
            UserId = userId,
            TakeEntity = 5
        });

        return View(model: result);
    }
}