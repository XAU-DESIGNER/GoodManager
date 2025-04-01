using GoodManager.Domain.DTOs.ViewModels.Common;
using Mapster;

namespace GoodManager.Web.Extensions;

public static class UserExtensions
{
    public static UserIdentitiesViewModel? GetUserIdentities(this HttpContext? context)
    {
        if (context?.Items["CurrentUser"] == null) return null;

        try
        {
            return context?.Items["CurrentUser"] as UserIdentitiesViewModel;
        }
        catch
        {
            return null;
        }
    }
    //public static string GetUserName(this HttpContext? context)
    //{
    //    if (context?.Items["CurrentUser"] == null) return "بدون نام کاربـری";
    //    var identities = context?.Items["CurrentUser"].Adapt<UserIdentitiesViewModel>();

    //    return identities?.UserName ?? "بدون نام کاربـری";
    //}
}