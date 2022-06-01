using MediatR;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItems.Commands.DeleteRentItem;
public record DeleteRentItemCommand(int Id) : IRequest;

public class DeleteRentItemCommandHandler : IRequestHandler<DeleteRentItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRentItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRentItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentItem), request.Id);
        }

        _context.RentItems.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
