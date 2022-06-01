using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Application.Common.Mappings;
using VacationHire.Application.Common.Models;

namespace VacationHire.Application.RentItems.Queries.GetRentItems;
public record GetRentItemsQuery : IRequest<PaginatedList<RentItemListDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRentItemsQueryHandler : IRequestHandler<GetRentItemsQuery, PaginatedList<RentItemListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RentItemListDto>> Handle(GetRentItemsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .OrderBy(x => x.Name)
            .ProjectTo<RentItemListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
