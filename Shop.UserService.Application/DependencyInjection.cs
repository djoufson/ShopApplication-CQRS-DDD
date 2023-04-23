using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.UserService.Application.Authentication.Commands.Login;
using Shop.UserService.Application.Authentication.Commands.Register;
using Shop.UserService.Application.Common.Behaviors;

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
