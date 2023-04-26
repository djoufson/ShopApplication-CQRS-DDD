using AutoMapper;
using MediatR;
using Shop.CommandService.Application.Commands;

namespace Shop.CommandService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandController : ControllerBase
{
    private readonly ISender _sender;
    private IMapper _mapper;

    public CommandController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandDto>> GetAllCommands()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<CommandDto>> CreateCommand(CreateCommandRequestDto request)
    {
        var createCommand = _mapper.Map<CreateCommandCommand>(request);
        var response = await _sender.Send(createCommand);
        var responseDto = _mapper.Map<CommandDto>(response);
        return Ok(responseDto);
    }

    [HttpPut("{id}")]
    public ActionResult<CommandDto> RevokeCommand(string id)
    {
        return Ok();
    }
}
