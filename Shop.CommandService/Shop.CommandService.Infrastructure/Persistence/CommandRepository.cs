using Shop.CommandService.Application.Persistence;
using Shop.CommandService.Domain.CommandsAggregate;
using Shop.CommandService.Domain.CommandsAggregate.ValueObjects;
using Shop.CommandService.Domain.ProductAggregate;

namespace Shop.CommandService.Infrastructure.Persistence;

public class CommandRepository : ICommandRepository
{
    private static readonly List<Command> _commands;
    private readonly IProductRepository _productRepository;
    static CommandRepository()
    {
        _commands = new List<Command>();
    }
    public CommandRepository(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Command? Create(Command entity)
    {
        var product = _productRepository.Get(entity.ProductId);
        var newQuantity = product?.Quantity - entity.Quantity ?? -1;
        if (newQuantity >= 0)
        {
            entity.Status = CommandStatus.Accepted;
            _productRepository.UpdateQuantity(entity.ProductId, newQuantity);
            // Asynchronously rise an event to be consumed by the ProductService, that a new command has been accepted
        }
        else
        {
            entity.Status = CommandStatus.Rejected;
        }
        
        _commands.Add(entity);

        return entity;
    }

    public void Delete(CommandId id)
    {
        var command = _commands.FirstOrDefault(c => c.Id == id);
        _commands.Remove(command!);
    }

    public Command? Get(CommandId id)
    {
        return _commands.FirstOrDefault(c => c.Id == id);
    }

    public Command? Update(Command entity)
    {
        throw new NotImplementedException();
    }
}
