using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Controllers.Accounting;

public class AccountingController : SiteBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
