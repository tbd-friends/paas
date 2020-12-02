using FluentValidation;

namespace Gamer.Menu.Application.Commands.Validators
{
    public class CreateMenuValidator : AbstractValidator<CreateMenu>
    {
        public CreateMenuValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(20).NotEmpty();
        }
    }
}