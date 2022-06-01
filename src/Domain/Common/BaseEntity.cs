using System.ComponentModel.DataAnnotations.Schema;

namespace VacationHire.Domain.Common;

public abstract class BaseEntity<T>: BaseAuditableEntity
{
    public T Id { get; set; }
}
