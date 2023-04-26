using Shop.CommandService.Domain.ProductAggregate.ValueObjects;

namespace Shop.CommandService.Domain.ProductAggregate;

public class Product : AggregateRoot<ProductId>
{
    public string ExternalId { get; set; }
    public int Quantity { get; set; }
    private Product(ProductId id, string externalId) : base(id)
    {
        ExternalId = externalId;
    }

    public static Product Create(string externalId, int quantity = 0)
    {
        return new Product(ProductId.CreateUnique(), externalId) { Quantity = quantity };
    }
}
