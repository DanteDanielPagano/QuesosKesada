using System.ComponentModel.DataAnnotations;

namespace QuesosKesada.OrderSales.ViewModels.Models;
public class OrderModel
{
    [Required]
    public int CustomerId { get; set; }
    [Required, MaxLength(25, ErrorMessage = $"jklsjklsdhjklfdashjlksd")]
    public string ShippingAddress { get; set; }
    public string ShippingCity { get; set; }
    public string ShippingCountry { get; set; }
    public string ShippingPostalCode { get; set; }
    public List<OrderDetailModel> OrderDetails { get; set; }
}
