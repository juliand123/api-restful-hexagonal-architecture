using AwesomeShop.Application.UseCases;
using AwesomeShop.Application.UseCases.Orders.Add;
using AwesomeShop.Application.UseCases.Orders.GetAll;
using AwesomeShop.Application.UseCases.Orders.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeShop.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddUseCases();

        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IUseCase<NoInput, UseCaseResult<GetAllOrdersOutput>>, GetAllOrdersUseCase>();
        services.AddScoped<IUseCase<int, UseCaseResult<GetOrderByIdOutput>>, GetOrderByIdUseCase>();

        services.AddScoped<IAddOrderUseCase, AddOrderUseCase>();
        return services;
    }
}