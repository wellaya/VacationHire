using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VacationHire.Application.Common.Interfaces;

namespace VacationHire.Application.RentOrders.Queries.GetRentOrder;
public record GetRentOrderQuery(Guid Id) : IRequest<RentOrderDto>;

public class GetRentOrderQueryHandler : IRequestHandler<GetRentOrderQuery, RentOrderDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RentOrderDto> Handle(GetRentOrderQuery request, CancellationToken cancellationToken)
    {
        var rentOrder = await _context.RentOrders
            .ProjectTo<RentOrderDto>(_mapper.ConfigurationProvider)
            .Where(x => x.Id == request.Id).Distinct()
            .FirstOrDefaultAsync(cancellationToken);

        return rentOrder;
    }
}