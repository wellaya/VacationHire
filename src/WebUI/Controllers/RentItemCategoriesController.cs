using Microsoft.AspNetCore.Mvc;
using VacationHire.Application.Common.Models;
using VacationHire.Application.RentItemCategories.Commands.CreateRentItemCategory;
using VacationHire.Application.RentItemCategories.Commands.DeleteRentItemCategory;
using VacationHire.Application.RentItemCategories.Commands.UpdateRentItemCategory;
using VacationHire.Application.RentItemCategories.Queries.GetRentItemCategories;
using VacationHire.Application.RentItemCategories.Queries.GetRentItemCategory;

namespace VacationHire.WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentItemCategoriesController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<RentItemCategoryDto>> GetRentItemCategory(int id)
    {
        return await Mediator.Send(new GetRentItemCategoryQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<RentItemCategoryListDto>>> GetRentItemCategories([FromQuery] GetRentItemCategoriesQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateRentItemCategoryCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateRentItemCategoryCommand command)
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
        await Mediator.Send(new DeleteRentItemCategoryCommand(id));

        return NoContent();
    }
}
