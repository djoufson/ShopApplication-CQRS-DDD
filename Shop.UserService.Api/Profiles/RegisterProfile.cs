using Shop.UserService.Domain.UserAggregate;
using System;

namespace Shop.UserService.Api.Profiles;

public class RegisterProfile : Profile
{
	public RegisterProfile()
    {
        CreateMap<RegisterRequestDto, RegisterCommand>();
        CreateMap<(User user, string token), AuthCommandResponse>().ConstructUsing(tuple =>
            new AuthCommandResponse(
                tuple.user.Id.Id.ToString(),
                tuple.user.FirstName,
                tuple.user.LastName,
                tuple.user.Email,
                tuple.user.PhoneNumber,
                tuple.user.UserRoles.Select(role => role.Name).ToArray(),
                tuple.token));
    }
}
