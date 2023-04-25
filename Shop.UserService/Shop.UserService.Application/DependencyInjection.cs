using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.Common.Application_Layer.Behaviors;
using Shop.UserService.Application.Authentication.Commands.Login;
using Shop.UserService.Application.Authentication.Commands.Register;

namespace Shop.UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApllication(this IServiceCollection services)
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

        return services;
    }
}
