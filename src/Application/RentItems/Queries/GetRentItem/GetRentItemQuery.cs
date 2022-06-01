using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VacationHire.Application.Common.Interfaces;

namespace VacationHire.Application.RentItems.Queries.GetRentItem;
public record GetRentItemQuery(int Id) : IRequest<RentItemDto>;

public class GetRentItemQueryHandler : IRequestHandler<GetRentItemQuery, RentItemDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RentItemDto> Handle(GetRentItemQuery request, CancellationToken cancellationToken)
    {
        var rentItem = await _context.RentItems
            .ProjectTo<RentItemDto>(_mapper.ConfigurationProvider)
            .Where(x => x.Id == request.Id).Distinct()
            .FirstOrDefaultAsync(cancellationToken);

        return rentItem;
    }
}