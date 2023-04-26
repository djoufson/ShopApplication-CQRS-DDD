using FluentValidation;

namespace Shop.CommandService.Application.Validators;

public class CreateCommandValidator : AbstractValidator<CreateCommandCommand>
{
	public CreateCommandValidator()
	{
		RuleFor(c => c.ProductId).NotNull().NotEmpty();
        RuleFor(c => c.Quantity).GreaterThan(0);
    }
}
