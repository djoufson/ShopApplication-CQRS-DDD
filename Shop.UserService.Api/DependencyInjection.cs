using Shop.UserService.Infrastructure.Authentication;

namespace Shop.UserService.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
    {
        // Options
        services.AddSingleton(configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>());

        return services;
    }
}
