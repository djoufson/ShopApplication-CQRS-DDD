namespace Shop.ProductsService.Applicaiton.Products.Commands;

public record UpdateProductCommand(
    ) : IRequest<UpdateProductCommandResponse>;