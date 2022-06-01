using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacationHire.Domain.Entities;

namespace VacationHire.Infrastructure.Persistence.Configurations;
public class RentOrderConfiguration : IEntityTypeConfiguration<RentOrder>
{
    public void Configure(EntityTypeBuilder<RentOrder> builder)
    {
        builder.Property<string>("_inspectionData")
        .HasColumnName("InspectionDataStr");

        builder.Ignore(c => c.InspectionData);

    }
}
