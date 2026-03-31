using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Core.Models;

public class AddCartItemModel
{
    [Required(ErrorMessage = "User identifier is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Product identifier is required")]
    public Guid ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency must be exactly 3 characters")]
    [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Currency must be 3 uppercase letters")]
    public string Currency { get; set; } = null!;
}
