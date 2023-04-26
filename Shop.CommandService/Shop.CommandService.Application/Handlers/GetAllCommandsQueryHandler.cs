using AutoMapper;
using Shop.CommandService.Application.Persistence;
using Shop.CommandService.Application.Queries;

namespace Shop.CommandService.Application.Handlers;

public class GetAllCommandsQueryHandler : IRequestHandler<GetAllCommandsQuery, IEnumerable<CreateCommandResponse>>
{
    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public GetAllCommandsQueryHandler(ICommandRepository commandRepository, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
    }

    public Task<IEnumerable<CreateCommandResponse>> Handle(GetAllCommandsQuery request, CancellationToken cancellationToken)
    {
        var commands = _commandRepository.GetAll();

        // Convert the entity back to a response command and return it
        var response = _mapper.Map<IEnumerable<CreateCommandResponse>>(commands);

        return Task.FromResult(response);
    }
}
