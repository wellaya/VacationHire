using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Domain.Entities;

namespace VacationHire.Application.RentItemCategories.Commands.CreateRentItemCategory;
public record CreateRentItemCategoryCommand : IRequest<int>
{
    public string? Name { get; init; }
}

public class CreateRentItemCategoryCommandHandler : IRequestHandler<CreateRentItemCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRentItemCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRentItemCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new RentItemCategory
        {
            Name = request.Name
        };

        _context.RentItemCategories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}