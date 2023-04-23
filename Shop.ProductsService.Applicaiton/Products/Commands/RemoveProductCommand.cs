namespace Shop.ProductsService.Applicaiton.Products.Commands;

public record RemoveProductCommand(
    ) : IRequest<RemoveProductCommandResponse>;
