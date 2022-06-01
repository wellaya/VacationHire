using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace VacationHire.Application.RentItemCategories.Commands.UpdateRentItemCategory;
public class UpdateRentItemCategoryCommandValidator : AbstractValidator<UpdateRentItemCategoryCommand>
{
    public UpdateRentItemCategoryCommandValidator()
    {
        RuleFor(v => v.Name)
             .MaximumLength(200)
             .NotEmpty();
    }
}