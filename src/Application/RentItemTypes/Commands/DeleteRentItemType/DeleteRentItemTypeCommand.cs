using MediatR;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemTypes.Commands.DeleteRentItemType;
public record DeleteRentItemTypeCommand(int Id) : IRequest;

public class DeleteRentItemTypeCommandHandler : IRequestHandler<DeleteRentItemTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRentItemTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRentItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentItemTypes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentItemType), request.Id);
        }

        _context.RentItemTypes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
