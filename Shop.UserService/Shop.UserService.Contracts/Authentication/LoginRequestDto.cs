namespace Shop.UserService.Contracts.Authentication;

public record LoginRequestDto(
    string Email,
    string Password);