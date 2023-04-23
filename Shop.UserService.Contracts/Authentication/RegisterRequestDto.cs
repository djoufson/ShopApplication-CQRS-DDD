namespace Shop.UserService.Contracts.Authentication;

public record RegisterRequestDto(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PasswordConfirmation,
    int PhoneNumber);
