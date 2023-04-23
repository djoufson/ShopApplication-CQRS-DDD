using Microsoft.Extensions.DependencyInjection;
using Shop.ProductsService.Applicaiton.Persistence;
using Shop.ProductsService.Infrastructure.Persistence.Products;

namespace Shop.ProductsService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Add Repositories
        services.AddSingleton<IProductsRepository, ProductsRepository>();
        
        return services;
    }
}
