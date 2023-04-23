using Shop.Common.Domain_Layer.Models.Base;
using Shop.ProductsService.Domain.ProductAggregate.ValueObjects;

namespace Shop.ProductsService.Domain.ProductAggregate;

public sealed class Product : AggregateRoot<ProductId>
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    private Product(ProductId id, string productName, string description, decimal price, int quantity) : base(id)
    {
        ProductName = productName;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public static Product Create(string productName, string description, decimal price, int quantity)
    {
        return new Product(ProductId.CreateUnique(), productName, description, price, quantity);
    }
}
