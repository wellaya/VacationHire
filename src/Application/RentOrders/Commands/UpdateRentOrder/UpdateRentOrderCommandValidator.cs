using FluentValidation;

namespace VacationHire.Application.RentOrders.Commands.UpdateRentOrder;
public class UpdateRentOrderCommandValidator : AbstractValidator<UpdateRentOrderCommand>
{
    public UpdateRentOrderCommandValidator()
    {
        RuleFor(v => v.RentAmount)
             .NotEmpty();
    }
}