using MediatR;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemCategories.Commands.DeleteRentItemCategory;
public record DeleteRentItemCategoryCommand(int Id) : IRequest;

public class DeleteRentItemCategoryCommandHandler : IRequestHandler<DeleteRentItemCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRentItemCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRentItemCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentItemCategories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentItemCategory), request.Id);
        }

        _context.RentItemCategories.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
