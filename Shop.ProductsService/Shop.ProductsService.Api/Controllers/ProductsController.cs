namespace Shop.ProductsService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ProductsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductRequestDto request)
    {
        var command = _mapper.Map<AddProductCommand>(request);
        var response = await _sender.Send(command);
        var responseDto = _mapper.Map<ProductDto>(response);
        return Ok(responseDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var command = new GetAllProductsQuery();
        var response = await _sender.Send(command);
        var responseDto = _mapper.Map<IEnumerable<ProductDto>>(response);
        return Ok(responseDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var command = new GetSingleProductQuery(id);
        var response = await _sender.Send(command);
        var responseDto = _mapper.Map<ProductDto>(response);
        return Ok(responseDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProduct(string id)
    {
        var command = new RemoveProductCommand(id);
        var response = await _sender.Send(command);
        var responseDto = _mapper.Map<ProductDto>(response);
        return Ok(responseDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestDto request)
    {
        var command = _mapper.Map<UpdateProductCommand>(request);
        var response = await _sender.Send(command);
        var responseDto = _mapper.Map<ProductDto>(response);
        return Ok(responseDto);
    }
}
