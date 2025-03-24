using GoodManager.Domain.Interfaces.Accounting;
using GoodManager.Domain.Interfaces.LangCenter;
using GoodManager.Domain.Interfaces.Users;
using GoodManager.Infrastructure.Persistence;
using GoodManager.Infrastructure.Persistence.Repositories.Accounting;
using GoodManager.Infrastructure.Persistence.Repositories.LangCenter;
using GoodManager.Infrastructure.Persistence.Repositories.Users;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GoodManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);

        services.AddDbContext<GoodManagerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        #region Repositories

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWordRepository, WordRepository>();
        services.AddScoped<IAccountingTransactionRepository, AccountingTransactionRepository>();

        #endregion

        return services;
    }
}