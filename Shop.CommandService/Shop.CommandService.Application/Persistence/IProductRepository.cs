using Shop.CommandService.Domain.ProductAggregate;

namespace Shop.CommandService.Application.Persistence;

public interface IProductRepository
{
    bool Exists(string productExternalId);
    Product? AddProduct(Product product);
    Product? Get(string productExternalId);
    Product? UpdateQuantity(string productExternalId, int newQuantity);
}
