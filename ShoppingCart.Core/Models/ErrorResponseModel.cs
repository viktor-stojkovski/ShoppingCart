namespace ShoppingCart.Core.Models;

public class ErrorResponseModel
{
    public int StatusCode { get; set; }
    public string Code { get; set; } = null!;
    public string Message { get; set; } = null!;
}
