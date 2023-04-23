using FluentValidation;

namespace Shop.UserService.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        //RuleFor(x => x.Email).EmailAddress();
        //RuleFor(x => x.Password)
        //    .NotEmpty()
        //    .MinimumLength(6)
        //    .Custom((_, ctx) =>
        //    {
        //        ctx.InstanceToValidate.Password.Equals(ctx.InstanceToValidate.PasswordConfirmation);
        //    });
        //RuleFor(x => x.PhoneNumber)
        //    .NotEmpty()
        //    .NotEqual(0);
    }
}
