using GoodManager.Application.Extensions;
using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.Accounting.Controllers;

public class TransactionController(IAccountingTransactionService accountingTransactionService) : AccountingBaseController
{
    #region Filter

    public async Task<IActionResult> Filter(FilterAccountingTransactionViewModel filter)
    {
        filter.UserId = HttpContext.User.GetUserId();

        var result = await accountingTransactionService.FilterAsync(filter);

        return View(result);
    }

    public async Task<PartialViewResult> ListPartial(FilterAccountingTransactionViewModel filter)
    {
        filter.UserId = HttpContext.User.GetUserId();

        var result = await accountingTransactionService.FilterAsync(filter);

        return PartialView("ListPartial", result);
    }

    #endregion

    #region Create

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateAccountingTransactionViewModel model)
    {
        if (!ModelState.IsValid || model.Amount == 0) return BadRequest(ErrorMessages.NullValue);

        model.UserId = User.GetUserId();
        var result = await accountingTransactionService.CreateAsync(model);

        if (result.IsFailure) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    #endregion

    #region Update

    public async Task<IActionResult> Update(int id)
    {
        if (id <= 0) return BadRequest(ErrorMessages.NullValue);

        var result = await accountingTransactionService.GetByIdForUpdateAsync(id);

        if (result.IsFailure) return BadRequest();

        return PartialView("UpdatePartial", result.Value);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateAccountingTransactionViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ErrorMessages.NullValue);

        var result = await accountingTransactionService.UpdateAsync(model);

        if (result.IsFailure) return BadRequest(result.Message);

        return Ok(result.Message);
    }

    #endregion

    #region Details



    #endregion

    #region Delete

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0) return BadRequest(ErrorMessages.NullValue);

        var result = await accountingTransactionService.DeleteAsync(id);

        if (result.IsFailure) return BadRequest(result.Message);

        return Ok(result.Message);
    }

    #endregion
}