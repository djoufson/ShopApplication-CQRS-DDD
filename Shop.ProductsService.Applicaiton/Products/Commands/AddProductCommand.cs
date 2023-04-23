namespace Shop.ProductsService.Applicaiton.Products.Commands;

public record AddProductCommand(
    ) : IRequest<AddProductCommandResponse>;
