namespace Shop.ProductsService.Contracts.Dtos;

public record ProductDto(
    string Id,
    string ProductName,
    string Description,
    decimal Price,
    int Quantity);
