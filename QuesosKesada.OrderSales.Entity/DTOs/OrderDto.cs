namespace QuesosKesada.OrderSales.Entity.DTOs;
public class OrderDto
{
    public OrderDto(
        int idClient,
        string address,
        string city,
        string country,
        string zipCode,
        List<OrderDetailDto> orderDetails)
    {
        CustomerId = idClient;
        ShippingAddress = address;
        ShippingCity = city;
        ShippingCountry = country;
        ShippingPostalCode = zipCode;
        OrderDetails = orderDetails;
    }

    public int CustomerId { get; }
    public string ShippingAddress { get; }
    public string ShippingCity { get; }
    public string ShippingCountry { get; }
    public string ShippingPostalCode { get; }
    public List<OrderDetailDto> OrderDetails { get; }
}
