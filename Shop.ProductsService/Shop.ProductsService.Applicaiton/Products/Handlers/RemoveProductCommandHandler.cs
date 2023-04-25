namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class RemoveProductCommandHanler : IRequestHandler<RemoveProductCommand, RemoveProductCommandResponse>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public RemoveProductCommandHanler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public Task<RemoveProductCommandResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        _productsRepository.Delete(product.Id);
        var response = _mapper.Map<RemoveProductCommandResponse>(request);

        return Task.FromResult(response);
    }
}
