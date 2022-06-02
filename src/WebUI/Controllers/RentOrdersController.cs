using Microsoft.AspNetCore.Mvc;
using VacationHire.Application.Common.Models;
using VacationHire.Application.RentOrders.Commands.CreateRentOrder;
using VacationHire.Application.RentOrders.Commands.DeleteRentOrder;
using VacationHire.Application.RentOrders.Commands.UpdateRentOrder;
using VacationHire.Application.RentOrders.Queries.GetRentOrder;
using VacationHire.Application.RentOrders.Queries.GetRentOrders;

namespace VacationHire.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentOrdersController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<RentOrderDto>> GetRentOrder(Guid id)
    {
        return await Mediator.Send(new GetRentOrderQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<RentOrderListDto>>> GetCustomers([FromQuery] GetRentOrdersQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateRentOrderCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateRentOrderCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteRentOrderCommand(id));

        return NoContent();
    }
}
