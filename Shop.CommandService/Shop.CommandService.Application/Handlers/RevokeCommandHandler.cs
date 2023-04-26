using AutoMapper;
using Shop.CommandService.Application.Persistence;
using Shop.CommandService.Domain.CommandsAggregate.ValueObjects;

namespace Shop.CommandService.Application.Handlers;

public class RevokeCommandHandler : IRequestHandler<RevokeCommandCommand, CreateCommandResponse>
{
    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;

    public RevokeCommandHandler(ICommandRepository commandRepository, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
    }

    public Task<CreateCommandResponse> Handle(RevokeCommandCommand request, CancellationToken cancellationToken)
    {
        var response = _commandRepository.RevokeCommand(CommandId.CreateUnique(request.Id));
        if (response is null)
            throw new Exception();
        return Task.FromResult(_mapper.Map<CreateCommandResponse>(response));
    }
}
