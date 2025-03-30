using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.Accounting.Controllers;

public class HomeController : AccountingBaseController
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
