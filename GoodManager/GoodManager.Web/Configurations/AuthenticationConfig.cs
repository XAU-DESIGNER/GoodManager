using Microsoft.AspNetCore.Authentication.Cookies;

namespace GoodManager.Web.Configurations;

public static class AuthenticationConfig
{
    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            option.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(option =>
        {
            option.LoginPath = "/login";
            option.LogoutPath = "/logout";
            option.ExpireTimeSpan = TimeSpan.FromDays(365);
        });
    }
}