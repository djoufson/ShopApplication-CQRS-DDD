using Shop.UserService.Domain.UserAggregate;

namespace Shop.UserService.Api.Profiles;

public class LoginProfile : Profile
{
	public LoginProfile()
	{
		CreateMap<LoginRequestDto, LoginCommand>();
        CreateMap<AuthCommandResponse, AuthResponseDto>();
	}
}
