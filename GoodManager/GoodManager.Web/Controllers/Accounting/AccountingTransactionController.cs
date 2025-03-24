using GoodManager.Application.Extensions;
using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace GoodManager.Web.Controllers.Accounting;

public class AccountingTransactionController(IAccountingTransactionService accountingTransactionService) : SiteBaseController
{
    #region Filter

    public async Task<IActionResult> Filter(FilterAccountingTransactionViewModel filter)
    {
        var result = await accountingTransactionService.FilterAsync(filter);

        return View(result);
    }

    public async Task<PartialViewResult> ListPartial(FilterAccountingTransactionViewModel filter)
    {
        var result = await accountingTransactionService.FilterAsync(filter);

        return PartialView("ListPartial", result);
    }

    #endregion

    #region Create

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAccountingTransactionViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ErrorMessages.BadRequestError);

        model.UserId = User.GetUserId();
        var result = await accountingTransactionService.CreateAsync(model);

        if (result.IsFailure) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    #endregion

    #region Update



    #endregion

    #region Details



    #endregion

    #region Delete

    #endregion

    #region Recover

    #endregion
}