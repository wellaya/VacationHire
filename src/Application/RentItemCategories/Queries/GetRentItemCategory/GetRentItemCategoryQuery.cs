using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VacationHire.Application.Common.Interfaces;

namespace VacationHire.Application.RentItemCategories.Queries.GetRentItemCategories;

public record GetRentItemCategoryQuery(int Id) : IRequest<RentItemCategoryDto>;

public class GetRentItemCategoriesQueryHandler : IRequestHandler<GetRentItemCategoryQuery, RentItemCategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentItemCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RentItemCategoryDto> Handle(GetRentItemCategoryQuery request, CancellationToken cancellationToken)
    {
        var itemCategory = await _context.RentItemCategories
            .ProjectTo<RentItemCategoryDto>(_mapper.ConfigurationProvider)
            .Where(x => x.Id == request.Id).Distinct()
            .FirstOrDefaultAsync(cancellationToken);

        return itemCategory;
    }
}