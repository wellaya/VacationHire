using FluentValidation;

namespace VacationHire.Application.RentItems.Commands.UpdateRentItem;
public class UpdateRentItemCommandValidator : AbstractValidator<UpdateRentItemCommand>
{
    public UpdateRentItemCommandValidator()
    {
        RuleFor(v => v.Name)
             .MaximumLength(200)
             .NotEmpty();
    }
}