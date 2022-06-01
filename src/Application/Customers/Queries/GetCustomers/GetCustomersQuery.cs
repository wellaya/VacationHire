using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Application.Common.Mappings;
using VacationHire.Application.Common.Models;

namespace VacationHire.Application.Customers.Queries.GetCustomers;
public record GetCustomersQuery : IRequest<PaginatedList<CustomerListDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, PaginatedList<CustomerListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CustomerListDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers
            .OrderBy(x => x.Name)
            .ProjectTo<CustomerListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
