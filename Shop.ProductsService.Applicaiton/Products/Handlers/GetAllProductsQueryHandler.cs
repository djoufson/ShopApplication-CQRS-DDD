using Shop.ProductsService.Applicaiton.Products.Queries;

namespace Shop.ProductsService.Applicaiton.Products.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<AddProductCommandResponse>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public Task<IEnumerable<AddProductCommandResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _productsRepository.GetAll();
        var productsDto = _mapper.Map<IEnumerable<AddProductCommandResponse>>(products);
        return Task.FromResult(productsDto);
    }
}
