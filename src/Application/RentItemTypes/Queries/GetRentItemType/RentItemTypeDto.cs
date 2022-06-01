using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationHire.Application.Common.Mappings;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemTypes.Queries.GetRentItemType;
public class RentItemTypeDto : IMapFrom<RentItemType>
{
    public int Id { get; set; }

    public int RentItemCategoryId { get; set; }
    public string Name { get; set; }
}
