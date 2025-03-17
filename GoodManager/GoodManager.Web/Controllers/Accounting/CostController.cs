using GoodManager.Application.Services.Implementation.LangCenter;
using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.Accounting.Costs;
using GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Controllers.Accounting;

public class CostController(ICostService costService) : SiteBaseController
{
    #region Filter

    public async Task<IActionResult> Filter(FilterCostsViewModel filter)
    {
        var result = await costService.FilterAsync(filter);
        return View(result);
    }

    public async Task<PartialViewResult> ListPartial(FilterCostsViewModel filter)
    {
        var result = await costService.FilterAsync(filter);

        return PartialView("ListPartial", result);
    }

    #endregion

    #region Create

    //public IActionResult Create()
    //{
    //    return PartialView("CreatePartial");
    //}

    //[HttpPost, ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create(CreateWordViewModel model)
    //{
    //    if (!ModelState.IsValid) return BadRequest(ErrorMessages.NullValue);

    //    var result = await costService.CreateAsync(model);

    //    if (result.IsFailure) return BadRequest(result.Message);

    //    return Ok(result.Message);
    //}

    #endregion
}