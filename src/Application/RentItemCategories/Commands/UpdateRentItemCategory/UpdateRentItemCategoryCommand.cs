using MediatR;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemCategories.Commands.UpdateRentItemCategory;
public record UpdateRentItemCategoryCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
}

public class UpdateRentItemCategoryCommandHandler : IRequestHandler<UpdateRentItemCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRentItemCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateRentItemCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentItemCategories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentItemCategory), request.Id);
        }

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}