using Shop.ProductsService.Applicaiton.Persistence;
using Shop.ProductsService.Domain.ProductAggregate;
using Shop.ProductsService.Domain.ProductAggregate.ValueObjects;
using System.Collections.Immutable;

namespace Shop.ProductsService.Infrastructure.Persistence.Products;

public class ProductsRepository : IProductsRepository
{
    private static readonly List<Product> _products;

    static ProductsRepository()
    {
        _products = new List<Product>();
    }

    public Product Create(Product product)
    {
        if(_products.Contains(product))
            throw new Exception("This product already exists");

        _products.Add(product);
        return product;
    }
    public void Delete(ProductId id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        _products.Remove(product!);
    }

    public Product? Get(ProductId id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public IReadOnlyList<Product> GetAll()
    {
        return _products.ToImmutableList();
    }

    public Product? Update(Product product)
    {
        return product;
    }

    public Product? UpdatePrice(ProductId id, decimal price)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        product!.Price = price;

        return product;
    }

    public Product UpdateQuantity(ProductId id, int quantity)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        product!.Quantity = quantity;

        return product;
    }
}
