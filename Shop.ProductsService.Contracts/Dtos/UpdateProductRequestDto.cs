namespace Shop.ProductsService.Contracts.Dtos;

public record UpdateProductRequestDto(
    string Id,
    string ProductName,
    string Description,
    decimal Price,
    int Quantity);
