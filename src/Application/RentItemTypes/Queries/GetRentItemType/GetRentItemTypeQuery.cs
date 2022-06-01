using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VacationHire.Application.Common.Interfaces;

namespace VacationHire.Application.RentItemTypes.Queries.GetRentItemType;
public record GetRentItemTypeQuery(int Id) : IRequest<RentItemTypeDto>;

public class GetRentItemTypeQueryHandler : IRequestHandler<GetRentItemTypeQuery, RentItemTypeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentItemTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RentItemTypeDto> Handle(GetRentItemTypeQuery request, CancellationToken cancellationToken)
    {
        var rentItemType = await _context.RentItemTypes
            .ProjectTo<RentItemTypeDto>(_mapper.ConfigurationProvider)
            .Where(x => x.Id == request.Id).Distinct()
            .FirstOrDefaultAsync(cancellationToken);

        return rentItemType;
    }
}