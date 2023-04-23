namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class RemoveProductCommandHanler : IRequestHandler<RemoveProductCommand, RemoveProductCommandResponse>
{
    public Task<RemoveProductCommandResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
