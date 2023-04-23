namespace Shop.ProductsService.Applicaiton.Products.Queries;

public record GetSingleProductQuery(
    string Id) : IRequest<AddProductCommandResponse>;