using Shop.ProductsService.Contracts.Dtos;

namespace Shop.ProductsService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult AddProduct(AddProductRequestDto request)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveProduct(string id)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(string id, UpdateProductRequestDto request)
    {
        return Ok();
    }
}
