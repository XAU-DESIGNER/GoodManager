using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.LangCenter.Controllers;

[Authorize]
[Area("LangCenter")]
public class LangCenterBaseController : Controller
{
    #region Messages

    public readonly string ErrorMessage = "ErrorMessage";
    public readonly string SuccessMessage = "SuccessMessage";

    public readonly string ErrorMessageToast = "ErrorMessageToast";
    public readonly string SuccessMessageToast = "SuccessMessageToast";

    #endregion
}