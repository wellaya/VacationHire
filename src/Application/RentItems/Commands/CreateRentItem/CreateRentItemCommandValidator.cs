using FluentValidation;

namespace VacationHire.Application.RentItems.Commands.CreateRentItem;
public class CreateRentItemCommandValidator : AbstractValidator<CreateRentItemCommand>
{
    public CreateRentItemCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}