using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Controllers.Accounting;

public class AccountingController : SiteBaseController
{
    #region Index

    public IActionResult Index()
    {
        return View();
    }

    #endregion

    #region Analysis

    public IActionResult Analysis()
    {
        return View();
    }

    public IActionResult UserIncomeAndExpenses()
    {
        return Ok();
    }

    #endregion
}
