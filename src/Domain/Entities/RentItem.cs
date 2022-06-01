using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationHire.Domain.Entities;
public class RentItem : BaseEntity<int>
{
    public string Name { get; set; }
    public double RentAmount { get; set; }
    public int RentItemTypeId { get; set; }
    public virtual RentItemType RentItemType { get; set; }
}
