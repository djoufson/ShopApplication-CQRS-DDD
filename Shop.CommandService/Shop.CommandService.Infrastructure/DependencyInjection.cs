using Microsoft.Extensions.DependencyInjection;
using Shop.CommandService.Application.Persistence;
using Shop.CommandService.Infrastructure.Persistence;
using Shop.Common.Application_Layer.Services;
using Shop.Common.Infrastructure_Layer.Services;

namespace Shop.CommandService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICommandRepository, CommandRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}
