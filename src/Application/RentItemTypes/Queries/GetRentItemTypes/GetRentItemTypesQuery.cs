using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using VacationHire.Application.Common.Interfaces;
using VacationHire.Application.Common.Mappings;
using VacationHire.Application.Common.Models;

namespace VacationHire.Application.RentItemTypes.Queries.GetRentItemTypes;
public record GetRentItemTypesQuery : IRequest<PaginatedList<RentItemTypeListDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRentItemTypesQueryHandler : IRequestHandler<GetRentItemTypesQuery, PaginatedList<RentItemTypeListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentItemTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RentItemTypeListDto>> Handle(GetRentItemTypesQuery request, CancellationToken cancellationToken)
    {
        return await _context.RentItemTypes
            .OrderBy(x => x.Name)
            .ProjectTo<RentItemTypeListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
