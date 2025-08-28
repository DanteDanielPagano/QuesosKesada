using QuesosKesada.OrderSales.Entity.Enums;

namespace QuesosKesada.OrderSales.Entity.Entities;
public class OrderHeader
{

    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingCity { get; set; }
    public string ShippingCountry { get; set; }
    public string ShippingPostalCode { get; set; }

    // Implementation of business rules
    public ShippingType ShippingMethodId { get; set; } = ShippingType.Road;
    public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
    public decimal Discount { get; set; } = 0.10m;
    public DateTime OrderDate { get; set; } = DateTime.Now;
}
