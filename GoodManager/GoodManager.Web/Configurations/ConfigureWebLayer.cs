namespace GoodManager.Web.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureWebLayer(this IServiceCollection services)
    {
        #region Services

        services.ConfigureAuthentication();
        services.AddHttpContextAccessor();

        #endregion

        return services;
    }
}