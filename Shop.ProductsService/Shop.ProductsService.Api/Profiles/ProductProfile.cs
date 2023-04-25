namespace Shop.ProductsService.Api.Profiles;

public class ProductProfile : Profile
{
	public ProductProfile()
	{
		CreateMap<AddProductRequestDto, AddProductCommand>();
        CreateMap<AddProductCommand, Product>().ConstructUsing(src => Product.Create(
            src.ProductName,
            src.Description,
            src.Price,
            src.Quantity));

        CreateMap<Product, AddProductCommandResponse>().ConstructUsing(src => new AddProductCommandResponse(
            src.Id.ToString(),
            src.ProductName,
            src.Description,
            src.Price,
            src.Quantity));

        CreateMap<AddProductCommandResponse, ProductDto>();
    }
}
