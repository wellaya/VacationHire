using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentOrders.Queries.GetRentOrder;
public class RentOrderDto : IMapFrom<RentOrder>
{
    public Guid Id { get; set; }

    public int CustomerId { get; set; }
    public int RentItemId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal RentAmount { get; set; }
    public JObject? InspectionData { get; set; }
}
