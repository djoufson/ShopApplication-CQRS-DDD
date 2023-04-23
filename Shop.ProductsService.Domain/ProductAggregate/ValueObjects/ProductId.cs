using Shop.Common.Domain_Layer.Models.Base;

namespace Shop.ProductsService.Domain.ProductAggregate.ValueObjects;

public class ProductId : ValueObject
{
    public Guid Value { get; set; }

    private ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId CreateUnique()
    {
        return new ProductId(Guid.NewGuid());
    }

    public static ProductId CreateUnique(Guid id)
    {
        return new ProductId(id);
    }

    public override IEnumerable<object> GetEqualityComparer()
    {
        yield return Value;
    }
}
