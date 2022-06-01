using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VacationHire.Application.Common.Interfaces;

namespace VacationHire.Application.Customers.Queries.GetCustomer;
public record GetCustomerQuery(int Id) : IRequest<CustomerDto>;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .Where(x => x.Id == request.Id).Distinct()
            .FirstOrDefaultAsync(cancellationToken);

        return customer;
    }
}