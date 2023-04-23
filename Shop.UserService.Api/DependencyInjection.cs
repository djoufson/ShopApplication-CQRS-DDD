using Shop.UserService.Infrastructure.Authentication;

namespace Shop.UserService.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped(
            typeof(IPipelineBehavior<,>), 
            typeof(ValidationBehavior<,>));

        services.AddScoped<IValidator<LoginCommand>, LoginCommandValidator>();
        services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();

        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(
            typeof(LoginCommand).Assembly,
            typeof(RegisterCommand).Assembly));

        // Add Repositories
        services.AddSingleton<IRolesRepository, RolesRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Add Services
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        // Options
        services.AddSingleton(configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>());

        return services;
    }
}
