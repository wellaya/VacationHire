using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentOrders.Commands.CreateRentOrder;
public record CreateRentOrderCommand : IRequest<Guid>
{
    public int CustomerId { get; set; }
    public int RentItemId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal RentAmount { get; set; }
    public string InspectionData { get; set; }
}

public class CreateRentOrderCommandHandler : IRequestHandler<CreateRentOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateRentOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateRentOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new RentOrder
        {
            CustomerId = request.CustomerId,
            RentItemId = request.RentItemId,
            RentDate = request.RentDate,
            ReturnDate = request.ReturnDate,
            RentAmount = request.RentAmount,
            InspectionData = JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(request.InspectionData) ? "{}" : request.InspectionData) 
        };

        _context.RentOrders.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}