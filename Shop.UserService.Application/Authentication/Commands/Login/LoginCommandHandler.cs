using AutoMapper;
using Shop.UserService.Application.Common.Interfaces;
using Shop.UserService.Application.Persistence.Users;
using Shop.UserService.Domain.UserAggregate;

namespace Shop.UserService.Application.Authentication.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(
        IMapper mapper,
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<AuthCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Rretrieve the user from the database
        var user = _userRepository.GetByEmail(request.Email);
        if (user is null)
            throw new Exception();
        if (user.Password != request.Password)
            throw new Exception();

        var token = _jwtTokenGenerator.GenerateToken(user.Id.ToString(), user.Email, user.FirstName);
        var userResponse = _mapper.Map<AuthCommandResponse>((user, token));

        return Task.FromResult(userResponse);
    }
}
