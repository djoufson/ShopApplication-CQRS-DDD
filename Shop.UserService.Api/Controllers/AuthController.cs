namespace Shop.UserService.Api.Controllers;

public class AuthController : ApiBaseController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public AuthController(
        IMapper mapper, 
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginRequestDto request)
    {
        var command = _mapper.Map<LoginCommand>(request);
        var response = await _sender.Send(command);
        return Ok(_mapper.Map<AuthResponseDto>(response));
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterRequestDto request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var response = await _sender.Send(command);
        return Ok(_mapper.Map<AuthResponseDto>(response));
    }
}