namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class AddProductCommandHanler : IRequestHandler<AddProductCommand, AddProductCommandResponse>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;
    public AddProductCommandHanler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public Task<AddProductCommandResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        product = _productsRepository.Create(product);
        var productResponse = _mapper.Map<AddProductCommandResponse>(product);

        return Task.FromResult(productResponse);
    }
}
