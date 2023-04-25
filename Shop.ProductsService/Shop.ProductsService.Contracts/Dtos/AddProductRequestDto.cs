namespace Shop.ProductsService.Contracts.Dtos;

public record AddProductRequestDto(
    string ProductName,
    string Description,
    decimal Price,
    int Quantity);
