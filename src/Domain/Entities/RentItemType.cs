
namespace VacationHire.Domain.Entities;
public class RentItemType : BaseEntity<int>
{
    public int RentItemCategoryId { get; set; }
    public string Name { get; set; }
    public virtual RentItemCategory RentItemCategory { get; set; }
}

