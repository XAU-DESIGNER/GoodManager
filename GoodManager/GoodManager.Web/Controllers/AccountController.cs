using Microsoft.AspNetCore.Mvc;
using GoodManager.Web.ActionFilters;
using GoodManager.Domain.DTOs.ViewModels.Account;
using GoodManager.Domain.Common;
using GoodManager.Application.Services.Interfaces.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using GoodManager.Application.Statics;

namespace GoodManager.Web.Controllers;

public class AccountController(IAccountService accountService) : Controller
{
    #region Messages

    public readonly string ErrorMessage = "ErrorMessage";
    public readonly string SuccessMessage = "SuccessMessage";

    public readonly string ErrorMessageToast = "ErrorMessageToast";
    public readonly string SuccessMessageToast = "SuccessMessageToast";

    #endregion

    #region Register

    [HttpGet("register")]
    [OnlyUnAuthenticatedActionFilter]
    public IActionResult Register(string? returnUrl)
    {
        return View();
    }

    [OnlyUnAuthenticatedActionFilter]
    [HttpPost("register"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData[ErrorMessageToast] = ErrorMessages.NullValue;
            return View(model);
        }

        var result = await accountService.RegisterAsync(model);

        if (result.IsFailure)
        {
            TempData[ErrorMessageToast] = result.Message;
            return View(model);
        }

        TempData[SuccessMessageToast] = result.Message;
        return RedirectToAction("Login", "Account");
    }

    #endregion

    #region Login

    [HttpGet("login")]
    [OnlyUnAuthenticatedActionFilter]
    public IActionResult Login(string? returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl });

    [HttpPost("login"), ValidateAntiForgeryToken]
    [OnlyUnAuthenticatedActionFilter]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData[ErrorMessageToast] = ErrorMessages.NullValue;
            return View(model);
        }

        var result = await accountService.CheckAndGetUserForLoginAsync(model);

        if (result.IsFailure)
        {
            TempData[ErrorMessageToast] = result.Message;
            return View(model);
        }

        await LoginUser(result.Value, model.RememberMe);

        TempData[SuccessMessageToast] = result.Message;

        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            return Redirect(model.ReturnUrl);

        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }

    #endregion

    #region Logout

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction(nameof(Login) , "Account");
    }

    #endregion

    #region Utilities

    private async Task LoginUser(UserLoginInformationViewModel user, bool rememberMe)
    {
        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id!.Value.ToString())
            };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties
        {
            IsPersistent = rememberMe,
        };

        await HttpContext.SignInAsync(principal, properties);
    }

    #endregion
}