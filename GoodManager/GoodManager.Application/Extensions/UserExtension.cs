using GoodManager.Application.Statics;
using System.Security.Claims;

namespace GoodManager.Application.Extensions;

public static class UserExtension
{
    public static string GetUserName(this ClaimsPrincipal claims)
    {
        if (claims is null || !(claims.Identity?.IsAuthenticated ?? false)) return string.Empty;

        return claims.FindFirst(CustomClaimTypes.UserName)?.Value ?? string.Empty;
    }

    public static string GetUserEmail(this ClaimsPrincipal claims)
    {
        if (claims is null || !(claims.Identity?.IsAuthenticated ?? false)) return string.Empty;

        return claims.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
    }

    public static int GetUserId(this ClaimsPrincipal claims)
    {
        if (claims is null || !(claims.Identity?.IsAuthenticated ?? false)) return default;

        return int.Parse(claims.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
    }

    //public static UserIdentitiesViewModel GetUserIdentities(this ClaimsPrincipal claims)
    //{
    //	if (claims is null || !(claims.Identity?.IsAuthenticated ?? false)) return new UserIdentitiesViewModel();

    //	return new UserIdentitiesViewModel()
    //	{
    //		Id = int.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""),
    //		Email = claims.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty,
    //		UserName = claims.FindFirst(CustomClaimTypes.UserName)?.Value,
    //		AvatarName = claims.FindFirst(CustomClaimTypes.AvatarName)?.Value,
    //	};
    //}
}