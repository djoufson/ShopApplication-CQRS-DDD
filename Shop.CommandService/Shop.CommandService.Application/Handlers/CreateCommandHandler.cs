using AutoMapper;
using Shop.CommandService.Application.Persistence;
using Shop.Common.Application_Layer.Services;

namespace Shop.CommandService.Application.Handlers;

public class CreateCommandHandler : IRequestHandler<CreateCommandCommand, CreateCommandResponse>
{
    private readonly ICommandRepository _commandRepository;
    private readonly IMapper _mapper;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateCommandHandler(
        ICommandRepository commandRepository,
        IMapper mapper,
        IDateTimeProvider dateTimeProvider)
    {
        _commandRepository = commandRepository;
        _mapper = mapper;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<CreateCommandResponse> Handle(CreateCommandCommand request, CancellationToken cancellationToken)
    {
        // Create the Command entity
        var command = Command.Create(request.ProductId, request.Quantity, _dateTimeProvider.UtcNow);

        // Add the entity using the injected repository 
        command = _commandRepository.Create(command);

        // Convert the entity back to a response command and return it
        var response = _mapper.Map<CreateCommandResponse>(command);

        return Task.FromResult(response);
    }
}
