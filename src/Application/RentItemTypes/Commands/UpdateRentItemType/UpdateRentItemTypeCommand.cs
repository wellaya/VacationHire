using MediatR;
using VacationHire.Application.Common.Exceptions;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemTypes.Commands.UpdateRentItemType;
public record UpdateRentItemTypeCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public int RentItemCategoryId { get; set; }
}

public class UpdateRentItemTypeCommandHandler : IRequestHandler<UpdateRentItemTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRentItemTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateRentItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RentItemTypes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(RentItemType), request.Id);
        }

        entity.Name = request.Name;
        entity.RentItemCategoryId = request.RentItemCategoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}