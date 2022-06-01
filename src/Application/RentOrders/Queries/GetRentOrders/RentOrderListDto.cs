using Newtonsoft.Json.Linq;
using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentOrders.Queries.GetRentOrders;
public class RentOrderListDto : IMapFrom<RentOrder>
{
    public Guid Id { get; set; }

    public int CustomerId { get; set; }
    public int RentItemId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal RentAmount { get; set; }
    public JObject? InspectionData { get; set; }
}