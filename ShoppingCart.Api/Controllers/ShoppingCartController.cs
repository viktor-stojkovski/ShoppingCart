using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Core.Dtos;
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
        return NoContent();
    }

    [HttpGet("get/{userId:guid}")]
    public async Task<ActionResult<CartDto>> GetActiveCart(Guid userId, CancellationToken ct)
    {
        var cart = await _cartService.GetActiveCartAsync(userId, ct);
        return Ok(cart);
    }

    [HttpPut("item-quantity")]
    public async Task<IActionResult> UpdateItemQuantity([FromBody] UpdateCartItemQuantityModel model, CancellationToken ct)
    {
        await _cartService.UpdateCartItemQuantityAsync(model, ct);
        return NoContent();
    }
}
