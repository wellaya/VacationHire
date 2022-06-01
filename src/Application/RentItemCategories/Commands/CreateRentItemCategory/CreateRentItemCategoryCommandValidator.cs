using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace VacationHire.Application.RentItemCategories.Commands.CreateRentItemCategory;
public class CreateRentItemCategoryCommandValidator : AbstractValidator<CreateRentItemCategoryCommand>
{
    public CreateRentItemCategoryCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}