namespace Shop.UserService.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(string id, string email, string firstName);
}
