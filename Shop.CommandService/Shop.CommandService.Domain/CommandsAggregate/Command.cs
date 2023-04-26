namespace Shop.CommandService.Domain.CommandsAggregate;

public enum CommandStatus
{
    Pending,
    Accepted,
    Rejected,
    Achieved
}

public sealed class Command : AggregateRoot<CommandId>
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderedAt { get; set; }
    public CommandStatus Status { get; set; }

    private Command(CommandId id, string productId, int quantity) : base(id)
    {
        ProductId = productId;
        Quantity = quantity;
        Status = CommandStatus.Pending;
    }

    public static Command Create(string productId, int quantity, DateTime orderedAt)
    {
        return new Command(CommandId.CreateUnique(), productId, quantity)
        {
            OrderedAt = orderedAt
        };
    }
}
