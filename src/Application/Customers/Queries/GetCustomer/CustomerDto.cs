using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.Customers.Queries.GetCustomer;
public class CustomerDto : IMapFrom<Customer>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? PhineNumber { get; set; }
}
