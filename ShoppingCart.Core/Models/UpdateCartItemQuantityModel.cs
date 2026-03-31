using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Core.Models;

public class UpdateCartItemQuantityModel
{
    public Guid UserId { get; set; }
    public Guid CartItemId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
    public int Quantity { get; set; }
}
