using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.CommandService.Application.Validators;
using Shop.Common.Application_Layer.Behaviors;

namespace Shop.CommandService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add Automapper stuff
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        // Add validators
        services.AddScoped<IValidator<CreateCommandCommand>, CreateCommandValidator>();

        // Add MediatR
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(
            typeof(CreateCommandCommand).Assembly));

        return services;
    }
}
