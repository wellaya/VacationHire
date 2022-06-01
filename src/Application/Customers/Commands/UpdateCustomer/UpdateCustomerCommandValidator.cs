using FluentValidation;

namespace VacationHire.Application.Customers.Commands.UpdateCustomer;
public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(v => v.Name)
             .MaximumLength(200)
             .NotEmpty();

        RuleFor(v => v.PhoneNumber)
            .MaximumLength(15)
            .NotEmpty();
    }
}