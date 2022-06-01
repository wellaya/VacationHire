using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Application.Common.Mappings;
using VacationHire.Application.Common.Models;

namespace VacationHire.Application.RentItemCategories.Queries.GetRentItemCategory;
public record GetRentItemCategoriesQuery : IRequest<PaginatedList<RentItemCategoryListDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRentItemCategoryQueryHandler : IRequestHandler<GetRentItemCategoriesQuery, PaginatedList<RentItemCategoryListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentItemCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RentItemCategoryListDto>> Handle(GetRentItemCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .OrderBy(x => x.Name)
            .ProjectTo<RentItemCategoryListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
