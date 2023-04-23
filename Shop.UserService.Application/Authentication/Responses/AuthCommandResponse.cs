namespace Shop.UserService.Application.Authentication.Responses;

public record AuthCommandResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    int PhoneNumber,
    string[] Roles,
    string Token);
