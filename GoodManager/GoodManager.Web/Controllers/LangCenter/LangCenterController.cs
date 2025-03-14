using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Controllers.LangCenter;

public class LangCenterController : SiteBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}