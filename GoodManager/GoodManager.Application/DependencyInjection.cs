using GoodManager.Application.Services.Implementation.Accounting;
using GoodManager.Application.Services.Implementation.LangCenter;
using GoodManager.Application.Services.Implementation.Users;
using GoodManager.Application.Services.Interfaces.Accounting;
using GoodManager.Application.Services.Interfaces.LangCenter;
using GoodManager.Application.Services.Interfaces.Users;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GoodManager.Application;

public static class DependencyInjection
{
    public static void ConfigureApplicationLayer(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);

        #region Services

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IWordService, WordService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountingTransactionService, AccountingTransactionService>();

        #endregion
    }
}