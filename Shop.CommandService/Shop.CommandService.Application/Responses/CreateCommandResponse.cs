namespace Shop.CommandService.Application.Responses;

public record CreateCommandResponse(
    string Id,
    string ProductId,
    int Quantity,
    int Status,
    DateTime OrderedAt);
