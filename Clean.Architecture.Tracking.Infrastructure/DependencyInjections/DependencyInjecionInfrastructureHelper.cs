using Clean.Architecture.Tracking.Core.Repositories.Contracts;
using Clean.Architecture.Tracking.Infrastructure.Messaging.Contracts;
using Clean.Architecture.Tracking.Infrastructure.Messaging.Implementations;
using Clean.Architecture.Tracking.Infrastructure.Options;
using Clean.Architecture.Tracking.Infrastructure.Persistence.Repositories.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Clean.Architecture.Tracking.Infrastructure.DependencyInjections;

public static class DependencyInjecionInfrastructureHelper
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddMongoDb()
            .AddRepositories()
            .AddMessageBus();

        return services;
    }

    private static IServiceCollection AddMongoDb(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbOptions>(db =>
        {
            var configuration = db.GetService<IConfiguration>();
            var options = new MongoDbOptions();
            configuration.GetSection("MongoDb").Bind(options);

            return options;
        });

        services.AddSingleton<IMongoClient>(sp =>
        {
            var configiguration = sp.GetService<IConfiguration>();
            var options = sp.GetService<MongoDbOptions>();
            var mongoClient = new MongoClient(options.ConnectionString);
            var db = mongoClient.GetDatabase(options.DatabaseName);
            //var dbSeed = new DbSeed(db);
            //dbSeed.Seed();
            return mongoClient;
        });

        services.AddTransient(sp =>
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            var mongoClient = sp.GetService<IMongoClient>();
            var options = sp.GetService<MongoDbOptions>();
            return mongoClient.GetDatabase(options.DatabaseName);
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IShippingOrderUpdateRepository, ShippingOrderUpdateRepository>();

        return services;
    }

    private static IServiceCollection AddMessageBus(this IServiceCollection services)
    {
        services.AddScoped<IMessageBusService, RabbitMqService>();

        return services;
    }
}
