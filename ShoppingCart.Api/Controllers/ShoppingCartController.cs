using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.Models;

namespace ShoppingCart.Api.Controllers;

[ApiController]
[Route("api/cart")]
public class ShoppingCartController(ICartService _cartService) : ControllerBase
{
    [HttpPost("add-item")]
    public async Task<IActionResult> AddItem([FromBody] AddCartItemModel model, CancellationToken ct)
    {
        await _cartService.AddCartItemAsync(model, ct);
        return Ok();
    }
}
