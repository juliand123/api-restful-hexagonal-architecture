using AwesomeShop.Core.Repositories;
using AwesomeShop.Core.Repositories.Orders;
using AwesomeShop.Infrastructure.Persistence.Repositories;
using AwesomeShop.Infrastructure.Persistence.Repositories.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeShop.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        //services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IAzureTableOrderRepository, AzureTableOrderRepository>();

        return services;
    }
}