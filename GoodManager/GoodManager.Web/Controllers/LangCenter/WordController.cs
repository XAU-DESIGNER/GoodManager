using GoodManager.Application.Services.Interfaces.LangCenter;
using GoodManager.Domain.Common;
using GoodManager.Domain.DTOs.ViewModels.LangCenter.Words;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Controllers.LangCenter;

public class WordController(IWordService wordService) : SiteBaseController
{
    #region Filter

    public async Task<IActionResult> Filter(FilterWordsViewModel filter)
    {
        var result = await wordService.FilterAsync(filter);

        return View(result);
    }

    public async Task<PartialViewResult> ListPartial(FilterWordsViewModel filter)
    {
        var result = await wordService.FilterAsync(filter);

        return PartialView("ListPartial", result);
    }

    #endregion

    #region Create

    public IActionResult Create()
    {
        return PartialView("CreatePartial");
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateWordViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ErrorMessages.NullValue);

        var result = await wordService.CreateAsync(model);

        if (result.IsFailure) return BadRequest(result.Message);

        return Ok(result.Message);
    }

    #endregion

    #region Update

    public async Task<IActionResult> Update(int id)
    {
        if (id <= 0) return BadRequest(ErrorMessages.NullValue);

        var result = await wordService.GetByIdForUpdateAsync(id);

        if (result.IsFailure) return BadRequest(result.Message);

        return PartialView("UpdatePartial", result.Value);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateWordViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ErrorMessages.NullValue);

        var result = await wordService.UpdateAsync(model);

        if (result.IsFailure) return BadRequest(result.Message);

        return Ok(result.Message);
    }

    #endregion

    #region Details

    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0) return BadRequest(ErrorMessages.NullValue);

        var result = await wordService.GetByIdAsync(id);
        if (result.IsFailure) return BadRequest(result.Message);

        return PartialView("DetailsPartial", result.Value);
    }

    #endregion

    #region Delete

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0) return BadRequest(ErrorMessages.NullValue);

        var result = await wordService.DeleteAsync(id);

        if (result.IsFailure) return BadRequest(result.Message);

        return Ok(result.Message);
    }

    #endregion
}