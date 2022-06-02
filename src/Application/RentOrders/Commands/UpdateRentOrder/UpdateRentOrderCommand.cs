using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentOrders.Commands.UpdateRentOrder;
public record UpdateRentOrderCommand : IRequest
{
    public Guid Id { get; init; }
    public int CustomerId { get; set; }
    public int RentItemId { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal RentAmount { get; set; }
    public string InspectionData { get; set; }
}

public class UpdateRentOrderCommandHandler : IRequestHandler<UpdateRentOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRentOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateRentOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentOrders
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentOrder), request.Id);
        }

        entity.CustomerId = request.CustomerId;
        entity.RentItemId = request.RentItemId;
        entity.RentDate = request.RentDate;
        entity.ReturnDate = request.ReturnDate;
        entity.RentAmount = request.RentAmount;
        entity.InspectionData = JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(request.InspectionData) ? "{}" : request.InspectionData);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}