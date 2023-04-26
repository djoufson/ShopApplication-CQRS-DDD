using AutoMapper;
using MediatR;
using Shop.CommandService.Application.Commands;
using Shop.CommandService.Application.Queries;

namespace Shop.CommandService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CommandController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommandDto>>> GetAllCommands()
    {
        var query = new GetAllCommandsQuery();
        var response = await _sender.Send(query);
        var responseDto = _mapper.Map<IEnumerable<CommandDto>>(response);
        return Ok(responseDto);
    }

    [HttpPost]
    public async Task<ActionResult<CommandDto>> CreateCommand(CreateCommandRequestDto request)
    {
        var createCommand = _mapper.Map<CreateCommandCommand>(request);
        var response = await _sender.Send(createCommand);
        var responseDto = _mapper.Map<CommandDto>(response);
        return Ok(responseDto);
    }

    [HttpPut("revoke/{id}")]
    public async Task<ActionResult<CommandDto>> RevokeCommand(string id)
    {
        var command = new RevokeCommandCommand(id);
        var response = await _sender.Send(command);
        var responseDto = _mapper.Map<CommandDto>(response);
        return Ok(responseDto);
    }
}
