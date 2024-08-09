using Clean.Architecture.Tracking.Application.Models.Inputs;
using Clean.Architecture.Tracking.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Tracking.Api.Controllers;

[ApiController]
[Route("api/shipping-order-updates")]
public class ShippingOrderUpdatesController : ControllerBase
{
    private readonly IShippingOrderUpdateService _service;

    public ShippingOrderUpdatesController(IShippingOrderUpdateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddShippingOrderUpdateInputModel model)
    {
        await _service.AddUpdate(model);

        return NoContent();
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetAllByCode(string code)
    {
        var viewModel = await _service.GetAllByCode(code);

        return Ok(viewModel);
    }

}
