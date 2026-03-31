namespace ShoppingCart.Core.Models;

public class CheckoutCartModel
{
    public Guid UserId { get; set; }
    public Guid CartId { get; set; }
}
