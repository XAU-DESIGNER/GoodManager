using GoodManager.Application.Extensions;
using GoodManager.Application.Services.Interfaces.Users;

public class UserMiddleware
{
    private readonly RequestDelegate _next;

    public UserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserService userService)
    {
        if (context.User.Identity?.IsAuthenticated ?? false)
        {
            var user = await userService.GetUserIdentitiesById(context.User.GetUserId());

            if (user is null) context.Items["CurrentUser"] = null;

            context.Items["CurrentUser"] = user;
        }
        else
        {
            context.Items["CurrentUser"] = null;
        }

        await _next(context);
    }
}
