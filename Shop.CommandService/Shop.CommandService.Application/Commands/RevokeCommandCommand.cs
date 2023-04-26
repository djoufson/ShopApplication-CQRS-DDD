namespace Shop.CommandService.Application.Commands;

public record RevokeCommandCommand(
    string Id) : IRequest<CreateCommandResponse>;
