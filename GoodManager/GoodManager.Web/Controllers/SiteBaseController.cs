using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Controllers;

[Authorize]
public class SiteBaseController : Controller
{
    #region Messages

    public readonly string ErrorMessage = "ErrorMessage";
    public readonly string SuccessMessage = "SuccessMessage";

    public readonly string ErrorMessageToast = "ErrorMessageToast";
    public readonly string SuccessMessageToast = "SuccessMessageToast";

    #endregion
}