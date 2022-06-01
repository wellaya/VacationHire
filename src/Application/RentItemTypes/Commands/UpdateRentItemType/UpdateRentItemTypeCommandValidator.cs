using FluentValidation;

namespace VacationHire.Application.RentItemTypes.Commands.UpdateRentItemType;
public class UpdateRentItemTypeCommandValidator : AbstractValidator<UpdateRentItemTypeCommand>
{
    public UpdateRentItemTypeCommandValidator()
    {
        RuleFor(v => v.Name)
             .MaximumLength(200)
             .NotEmpty();
    }
}