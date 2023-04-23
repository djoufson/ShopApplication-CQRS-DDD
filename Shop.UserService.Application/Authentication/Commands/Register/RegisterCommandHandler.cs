using AutoMapper;
using Shop.UserService.Application.Common.Interfaces;
using Shop.UserService.Application.Persistence.Users;
using Shop.UserService.Domain.UserAggregate;

namespace Shop.UserService.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<AuthCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check if the user already exists

        // Create a user
        var user = User.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.PhoneNumber);

        
        // Persist the user to the database
        user = _userRepository.Create(user);
        
        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user.Id.ToString(), user.Email, user.FirstName);
        
        // Return the mapped informations
        var userDto = _mapper.Map<AuthCommandResponse>((user, token));
        return Task.FromResult(userDto);
    }
}
