using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VacationHire.Domain.Entities;
public class RentOrder: BaseEntity<Guid>
{
    private string? _inspectionData;
    public int CustomerId { get; set; }
    public int RentItemId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public JObject? InspectionData
    {
        get => JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(_inspectionData) ? "{}" : _inspectionData);
        set
        {
            _inspectionData = value.ToString();
        }
    }
    public decimal RentAmount { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual RentItem RentItem { get; set; }
}
