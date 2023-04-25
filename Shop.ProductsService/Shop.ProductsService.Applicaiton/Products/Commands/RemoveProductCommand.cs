namespace Shop.ProductsService.Applicaiton.Products.Commands;

public record RemoveProductCommand(
    string Id) : IRequest<RemoveProductCommandResponse>;
