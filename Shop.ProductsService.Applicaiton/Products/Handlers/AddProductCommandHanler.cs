namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class AddProductCommandHanler : IRequestHandler<AddProductCommand, AddProductCommandResponse>
{
    public Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
