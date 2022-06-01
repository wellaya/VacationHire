using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemTypes.Queries.GetRentItemTypes;
public class RentItemTypeListDto : IMapFrom<RentItemType>
{
    public int Id { get; set; }

    public int RentItemCategoryId { get; set; }
    public string Name { get; set; }
}