using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemCategories.Queries.GetRentItemCategories;
public class RentItemCategoryDto : IMapFrom<RentItemCategory>
{
    public int Id { get; set; }

    public string? Name { get; set; }
}

