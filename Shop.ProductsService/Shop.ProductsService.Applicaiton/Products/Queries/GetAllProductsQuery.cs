namespace Shop.ProductsService.Applicaiton.Products.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<AddProductCommandResponse>>;