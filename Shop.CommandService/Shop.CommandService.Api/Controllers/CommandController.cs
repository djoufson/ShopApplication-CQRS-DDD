namespace Shop.CommandService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CommandDto>> GetAllCommands()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<CommandDto> CreateCommand(CreateCommandRequestDto request)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult<CommandDto> RevokeCommand(string id)
    {
        return Ok();
    }
}
