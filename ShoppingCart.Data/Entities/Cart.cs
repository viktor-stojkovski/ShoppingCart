using ShoppingCart.Data.Enums;

namespace ShoppingCart.Data.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public string Currency { get; set; } = null!;
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public CartStatusEnum Status { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = [];
}
