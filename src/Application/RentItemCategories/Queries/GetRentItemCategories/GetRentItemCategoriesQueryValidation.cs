using FluentValidation;

namespace VacationHire.Application.RentItemCategories.Queries.GetRentItemCategory;
public class GetRentItemCategoriesQueryValidation : AbstractValidator<GetRentItemCategoriesQuery>
{
    public GetRentItemCategoriesQueryValidation()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}