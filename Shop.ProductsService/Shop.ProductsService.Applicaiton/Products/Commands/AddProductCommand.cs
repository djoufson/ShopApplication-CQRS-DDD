namespace Shop.ProductsService.Applicaiton.Products.Commands;

public record AddProductCommand(
    string ProductName,
    string Description,
    decimal Price,
    int Quantity) : IRequest<AddProductCommandResponse>;
