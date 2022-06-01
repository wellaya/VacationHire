using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Application.Common.Mappings;
using VacationHire.Application.Common.Models;

namespace VacationHire.Application.RentOrders.Queries.GetRentOrders;
public record GetRentOrdersQuery : IRequest<PaginatedList<RentOrderListDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRentOrdersQueryHandler : IRequestHandler<GetRentOrdersQuery, PaginatedList<RentOrderListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RentOrderListDto>> Handle(GetRentOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .OrderBy(x => x.Name)
            .ProjectTo<RentOrderListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
