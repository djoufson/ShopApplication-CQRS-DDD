using AutoMapper;
using Shop.CommandService.Application.Commands;
using Shop.CommandService.Application.Responses;
using Shop.CommandService.Domain.CommandsAggregate;

namespace Shop.CommandService.Api.Profiles;

public class CommandProfile : Profile
{
	public CommandProfile()
	{
        CreateMap<CreateCommandRequestDto, CreateCommandCommand>();
		CreateMap<CreateCommandCommand, Command>();
        CreateMap<Command, CreateCommandResponse>();
        CreateMap<CreateCommandResponse, CommandDto>();
    }
}
