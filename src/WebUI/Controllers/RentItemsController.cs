using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacationHire.Application.Common.Models;
using VacationHire.Application.RentItems.Commands.CreateRentItem;
using VacationHire.Application.RentItems.Commands.DeleteRentItem;
using VacationHire.Application.RentItems.Commands.UpdateRentItem;
using VacationHire.Application.RentItems.Queries.GetRentItem;
using VacationHire.Application.RentItems.Queries.GetRentItems;

namespace VacationHire.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentItemsController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<RentItemDto>> GetRentItem(int id)
    {
        return await Mediator.Send(new GetRentItemQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<RentItemListDto>>> GetRentItems([FromQuery] GetRentItemsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateRentItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateRentItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteRentItemCommand(id));

        return NoContent();
    }
}
