using VacationHire.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VacationHire.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<RentItem> RentItems { get; }
    DbSet<RentItemCategory> RentItemCategories { get; }
    DbSet<RentOrder> RentOrders { get; }
    DbSet<RentItemType> RentItemTypes { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
