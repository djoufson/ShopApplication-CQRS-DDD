namespace Shop.UserService.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PasswordConfirmation,
    int PhoneNumber) : IRequest<AuthCommandResponse>;
