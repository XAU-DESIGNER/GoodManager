using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.LangCenter.Controllers;

public class HomeController : LangCenterBaseController
{
    #region Index

    public IActionResult Index()
    {
        return View();
    }

    #endregion

    #region Exam center

    public IActionResult LangCenter()
    {
        return View();
    }

    #endregion
}