using Shop.CommandService.Application.Persistence;
using Shop.CommandService.Domain.ProductAggregate;
using Shop.CommandService.Domain.ProductAggregate.ValueObjects;

namespace Shop.CommandService.Infrastructure.Persistence;

internal class ProductRepository : IProductRepository
{
    private static readonly List<Product> _products;
    static ProductRepository()
    {
        _products = new List<Product>()
        {
            Product.Create("string", 50)
        };
    }

    public Product? AddProduct(Product product)
    {
        if (Exists(product.ExternalId))
            return null;

        _products.Add(product);
        return product;
    }

    public bool Exists(string productExternalId)
    {
        return _products.Any(p => p.ExternalId == productExternalId);
    }

    public Product? Get(string productExternalId)
    {
        return _products.FirstOrDefault(p => p.ExternalId == productExternalId);
    }

    public Product? UpdateQuantity(string productExternalId, int newQuantity)
    {
        var product = _products.FirstOrDefault(p => p.ExternalId == productExternalId);
        product!.Quantity = newQuantity;
        return product;
    }
}
