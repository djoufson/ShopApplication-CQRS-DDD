namespace Shop.UserService.Application.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password) : IRequest<AuthCommandResponse>;
