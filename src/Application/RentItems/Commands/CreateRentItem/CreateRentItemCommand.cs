using System;
using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItems.Commands.CreateRentItem;
public record CreateRentItemCommand : IRequest<int>
{
    public string Name { get; set; }
    public double RentAmount { get; set; }
    public int RentItemTypeId { get; set; }
}

public class CreateRentItemCommandHandler : IRequestHandler<CreateRentItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRentItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRentItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new RentItem
        {
            Name = request.Name,
            RentAmount = request.RentAmount,
            RentItemTypeId = request.RentItemTypeId
        };

        _context.RentItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}