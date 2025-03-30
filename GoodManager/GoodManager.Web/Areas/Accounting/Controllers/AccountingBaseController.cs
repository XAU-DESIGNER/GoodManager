using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodManager.Web.Areas.Accounting.Controllers;

[Authorize]
[Area("Accounting")]
public class AccountingBaseController : Controller
{
    #region Messages

    public readonly string ErrorMessage = "ErrorMessage";
    public readonly string SuccessMessage = "SuccessMessage";

    public readonly string ErrorMessageToast = "ErrorMessageToast";
    public readonly string SuccessMessageToast = "SuccessMessageToast";

    #endregion
}