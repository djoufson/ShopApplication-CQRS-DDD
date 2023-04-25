namespace Shop.ProductsService.Applicaiton;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddScoped<IValidator<AddProductCommand>, AddProductCommandValidator>();
        services.AddScoped<IValidator<RemoveProductCommand>, RemoveProductCommandValidator>();
        services.AddScoped<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();

        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(
            typeof(AddProductCommand).Assembly,
            typeof(RemoveProductCommand).Assembly,
            typeof(UpdateProductCommand).Assembly));

        return services;
    }
}
