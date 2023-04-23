namespace Shop.UserService.Contracts.Authentication;

public record AuthResponseDto(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    int PhoneNumber,
    string Token,
    string[] Roles);
