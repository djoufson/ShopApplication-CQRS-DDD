namespace Shop.UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Add Repositories
        services.AddSingleton<IRolesRepository, RolesRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Add Services
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}
