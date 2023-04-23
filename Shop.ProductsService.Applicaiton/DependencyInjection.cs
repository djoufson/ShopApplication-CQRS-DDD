using Microsoft.Extensions.DependencyInjection;

namespace Shop.ProductsService.Applicaiton;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
