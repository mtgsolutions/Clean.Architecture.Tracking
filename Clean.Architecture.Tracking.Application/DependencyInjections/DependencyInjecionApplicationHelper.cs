using Clean.Architecture.Tracking.Application.Services.Contracts;
using Clean.Architecture.Tracking.Application.Services.Implementations;
using Clean.Architecture.Tracking.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.Tracking.Application.DependencyInjections;

public static class DependencyInjecionApplicationHelper
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRabbitMq(configuration)
            .AddApplicationServices();

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IShippingOrderUpdateService, ShippingOrderUpdateService>();

        return services;
    }

    private static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqOptions>(options => configuration.GetSection("RabbitMq").Bind(options));

        return services;
    }
}
