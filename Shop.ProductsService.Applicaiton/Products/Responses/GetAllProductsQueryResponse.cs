namespace Shop.ProductsService.Applicaiton.Products.Responses;

public record GetAllProductsQueryResponse(
    IEnumerable<AddProductCommandResponse> Products);
