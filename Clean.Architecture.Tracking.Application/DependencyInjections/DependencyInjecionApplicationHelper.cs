using Clean.Architecture.Tracking.Application.Services.Contracts;
using Clean.Architecture.Tracking.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.Tracking.Application.DependencyInjections;

public static class DependencyInjecionApplicationHelper
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddApplicationServices();

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IShippingOrderUpdateService, ShippingOrderUpdateService>();

        return services;
    }
}
