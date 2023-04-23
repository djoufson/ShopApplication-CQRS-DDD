namespace Shop.ProductsService.Applicaiton.Persistence;

public interface IProductsRepository : IRepository<ProductId, Product>
{
    Product? UpdatePrice(ProductId id, decimal price);
    Product? UpdateQuantity(ProductId id, int quantity);
}
