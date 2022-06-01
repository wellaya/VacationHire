using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationHire.Domain.Entities;
public class RentItemCategory: BaseEntity<int>
{
    public string Name { get; set; }
    public virtual List<RentItemType> RentItemTypes { get; set; }
}
