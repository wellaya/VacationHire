using FluentValidation;

namespace VacationHire.Application.RentOrders.Commands.CreateRentOrder;
public class CreateRentOrderCommandValidator : AbstractValidator<CreateRentOrderCommand>
{
    public CreateRentOrderCommandValidator()
    {
        RuleFor(v => v.RentAmount)
            .NotEmpty();
    }
}