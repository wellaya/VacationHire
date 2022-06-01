using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VacationHire.Application.Common.Models;
using VacationHire.Application.Customers.Commands.CreateCustomer;
using VacationHire.Application.Customers.Commands.DeleteCustomer;
using VacationHire.Application.Customers.Commands.UpdateCustomer;
using VacationHire.Application.Customers.Queries.GetCustomer;
using VacationHire.Application.Customers.Queries.GetCustomers;

namespace VacationHire.WebUI.Controllers;

//[Authorize]
public class CustomersController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        return await Mediator.Send(new GetCustomerQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CustomerListDto>>> GetCustomers([FromQuery] GetCustomersQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCustomerCommand command)
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
        await Mediator.Send(new DeleteCustomerCommand(id));

        return NoContent();
    }
}
