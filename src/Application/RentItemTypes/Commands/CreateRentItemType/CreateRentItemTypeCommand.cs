using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemTypes.Commands.CreateRentItemType;
public record CreateRentItemTypeCommand : IRequest<int>
{
    public string? Name { get; init; }
    public int RentItemCategoryId { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateRentItemTypeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRentItemTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = new RentItemType
        {
            Name = request.Name,
            RentItemCategoryId = request.RentItemCategoryId
        };

        _context.RentItemTypes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}