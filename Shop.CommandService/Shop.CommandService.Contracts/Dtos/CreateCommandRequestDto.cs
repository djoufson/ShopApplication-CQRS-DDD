namespace Shop.CommandService.Contracts.Dtos;

public record CreateCommandRequestDto(
    string ProductId,
    int Quantity);