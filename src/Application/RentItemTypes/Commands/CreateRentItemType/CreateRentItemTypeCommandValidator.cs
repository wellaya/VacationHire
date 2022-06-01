using FluentValidation;

namespace VacationHire.Application.RentItemTypes.Commands.CreateRentItemType;
public class CreateRentItemTypeCommandValidator : AbstractValidator<CreateRentItemTypeCommand>
{
    public CreateRentItemTypeCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}