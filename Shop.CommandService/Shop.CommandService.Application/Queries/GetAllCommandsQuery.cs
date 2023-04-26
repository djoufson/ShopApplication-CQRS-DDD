namespace Shop.CommandService.Application.Queries;

public record GetAllCommandsQuery(
    ) : IRequest<IEnumerable<CreateCommandResponse>>;
