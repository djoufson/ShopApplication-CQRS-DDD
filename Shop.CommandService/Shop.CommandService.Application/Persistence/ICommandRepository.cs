using Shop.CommandService.Domain.CommandsAggregate.ValueObjects;

namespace Shop.CommandService.Application.Persistence;

public interface ICommandRepository : IRepository<CommandId, Command>
{
    IReadOnlyList<Command> GetAll();
    Command? RevokeCommand(CommandId id);
}
