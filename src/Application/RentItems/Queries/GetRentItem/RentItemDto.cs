using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItems.Queries.GetRentItem;
public class RentItemDto : IMapFrom<RentItem>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double RentAmount { get; set; }
    public int RentItemTypeId { get; set; }
}
