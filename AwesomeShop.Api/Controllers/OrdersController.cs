using AwesomeShop.Application.UseCases;
using AwesomeShop.Application.UseCases.Orders.Add;
using AwesomeShop.Application.UseCases.Orders.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    // Ports HTTP definidos

    [HttpPost]
    public async Task<IActionResult> Post(AddOrderInput input, [FromServices] IAddOrderUseCase useCase)
    {
        var result = await useCase.Execute(input);

        return CreatedAtAction(nameof(GetById), new { id = result }, input);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IUseCase<NoInput, UseCaseResult<GetAllOrdersOutput>> useCase)
    {
        var result = await useCase.Execute();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id,
        [FromServices] IUseCase<int, UseCaseResult> useCase)
    {
        var result = await useCase.Execute(id);

        if (result == null) return NotFound();

        return Ok(result);
    }
}