namespace Shop.ProductsService.Applicaiton.Products.Commands;

public record AddProductCommandResponse(
    string Id,
    string ProductName,
    string Description,
    decimal Price,
    int Quantity);
