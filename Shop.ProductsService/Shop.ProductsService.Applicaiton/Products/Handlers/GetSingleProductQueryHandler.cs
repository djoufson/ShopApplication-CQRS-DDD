using Shop.ProductsService.Applicaiton.Products.Queries;

namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQuery, AddProductCommandResponse>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public GetSingleProductQueryHandler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public Task<AddProductCommandResponse> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
    {
        var productId = ProductId.CreateUnique(Guid.Parse(request.Id));
        var product = _productsRepository.Get(productId);
        var productsDto = _mapper.Map<AddProductCommandResponse>(product);
        return Task.FromResult(productsDto);
    }
}
