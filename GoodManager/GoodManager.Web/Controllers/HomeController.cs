using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Controllers;

public class HomeController : SiteBaseController
{
    public IActionResult Index() => View();
}