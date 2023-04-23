namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class UpdateProductCommandHanler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
{
    public Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
