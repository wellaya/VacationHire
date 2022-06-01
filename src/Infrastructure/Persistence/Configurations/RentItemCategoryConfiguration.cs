using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationHire.Domain.Entities;

namespace VacationHire.Infrastructure.Persistence.Configurations;
public class RentItemCategoryConfiguration : IEntityTypeConfiguration<RentItemCategory>
{
    public void Configure(EntityTypeBuilder<RentItemCategory> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
