namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class UpdateProductCommandHanler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHanler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        product = _productsRepository.Update(product);
        var response = _mapper.Map<UpdateProductCommandResponse>(product);

        return Task.FromResult(response);
    }
}
