using Microsoft.AspNetCore.Mvc.Filters;

namespace GoodManager.Web.ActionFilters;

public class OnlyUnAuthenticatedActionFilter: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        if (context.HttpContext.User?.Identity?.IsAuthenticated ?? true)
            context.HttpContext.Response.Redirect("/");
    }
}