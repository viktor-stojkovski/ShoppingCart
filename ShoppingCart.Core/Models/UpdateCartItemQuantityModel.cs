using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Core.Models;

public class UpdateCartItemQuantityModel
{
    [Required(ErrorMessage = "User identifier is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Cart item identifier is required")]
    public Guid CartItemId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
    public int Quantity { get; set; }
}
