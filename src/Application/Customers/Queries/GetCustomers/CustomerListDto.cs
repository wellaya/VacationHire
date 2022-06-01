using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.Customers.Queries.GetCustomers;
public class CustomerListDto : IMapFrom<Customer>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }
}
