using MediatR;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItems.Commands.UpdateRentItem;
public record UpdateRentItemCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; set; }
    public double RentAmount { get; set; }
    public int RentItemTypeId { get; set; }
}

public class UpdateRentItemCommandHandler : IRequestHandler<UpdateRentItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRentItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateRentItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentItem), request.Id);
        }

        entity.Name = request.Name;
        entity.RentAmount = request.RentAmount;
        entity.RentItemTypeId = request.RentItemTypeId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}