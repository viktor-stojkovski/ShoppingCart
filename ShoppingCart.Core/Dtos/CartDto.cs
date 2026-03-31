using ShoppingCart.Data.Enums;

namespace ShoppingCart.Core.Dtos;

public class CartDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Currency { get; set; } = null!;
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public CartStatusEnum Status { get; set; }
    public IList<CartItemDto> CartItems { get; set; } = [];
    public decimal TotalAmount { get; set; }
}
