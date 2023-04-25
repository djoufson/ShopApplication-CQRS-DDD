namespace Shop.ProductsService.Applicaiton.Products.Commands;

public record UpdateProductCommand(
    string Id,
    string ProductName,
    string Description,
    decimal Price,
    int Quantity) : IRequest<UpdateProductCommandResponse>;