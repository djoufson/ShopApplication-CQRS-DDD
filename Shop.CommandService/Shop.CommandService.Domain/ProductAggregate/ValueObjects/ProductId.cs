namespace Shop.CommandService.Domain.ProductAggregate.ValueObjects;

public class ProductId : ValueObject
{
    public Guid Value;

    public ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique()
    {
        return new ProductId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return Value;
    }
}
