using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacationHire.Application.Common.Models;
using VacationHire.Application.RentItemTypes.Commands.CreateRentItemType;
using VacationHire.Application.RentItemTypes.Commands.DeleteRentItemType;
using VacationHire.Application.RentItemTypes.Commands.UpdateRentItemType;
using VacationHire.Application.RentItemTypes.Queries.GetRentItemType;
using VacationHire.Application.RentItemTypes.Queries.GetRentItemTypes;

namespace VacationHire.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentItemTypesController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<RentItemTypeDto>> GetRentItemType(int id)
    {
        return await Mediator.Send(new GetRentItemTypeQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<RentItemTypeListDto>>> GetCustomers([FromQuery] GetRentItemTypesQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateRentItemTypeCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateRentItemTypeCommand command)
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
        await Mediator.Send(new DeleteRentItemTypeCommand(id));

        return NoContent();
    }
}
