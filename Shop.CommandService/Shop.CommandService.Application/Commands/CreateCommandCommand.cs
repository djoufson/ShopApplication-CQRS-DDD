namespace Shop.CommandService.Application.Commands;

public record CreateCommandCommand(
    string ProductId,
    int Quantity) : IRequest<CreateCommandResponse>;
