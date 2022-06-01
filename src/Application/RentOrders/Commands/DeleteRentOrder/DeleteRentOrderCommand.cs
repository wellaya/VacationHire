using MediatR;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentOrders.Commands.DeleteRentOrder;
public record DeleteRentOrderCommand(int Id) : IRequest;

public class DeleteRentOrderCommandHandler : IRequestHandler<DeleteRentOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRentOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRentOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentOrders
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentOrder), request.Id);
        }

        _context.RentOrders.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
