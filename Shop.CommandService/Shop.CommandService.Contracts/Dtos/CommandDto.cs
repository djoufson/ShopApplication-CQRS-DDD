namespace Shop.CommandService.Contracts.Dtos;

public record CommandDto(
    string Id,
    string ProductId,
    int Quantity,
    int Status,
    DateTime OrderedAt);