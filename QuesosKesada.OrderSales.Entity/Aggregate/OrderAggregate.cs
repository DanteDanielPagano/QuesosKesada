using QuesosKesada.OrderSales.Entity.DTOs;
using QuesosKesada.OrderSales.Entity.Entities;

namespace QuesosKesada.OrderSales.Entity.Aggregate;
public class OrderAggregate : OrderHeader
{
    readonly private List<OrderDetail> _orderDetailsField = new();
    public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetailsField;

    public void AddDetail(int productId, float unitPrice, int quantity)
    {
        var existinOrderDetail = _orderDetailsField.
            FirstOrDefault(o => o.ProductId == productId);

        if (existinOrderDetail != null)
        {
            quantity += existinOrderDetail.Quantity;
            _orderDetailsField.Remove(existinOrderDetail);
        }

        _orderDetailsField.Add(new OrderDetail(productId, unitPrice, quantity));
    }

    public static OrderAggregate From(OrderDto orderDto)
    {
        OrderAggregate order = new()
        {
            CustomerId = orderDto.CustomerId,
            ShippingAddress = orderDto.ShippingAddress,
            ShippingCity = orderDto.ShippingCity,
            ShippingCountry = orderDto.ShippingCountry,
            ShippingPostalCode = orderDto.ShippingPostalCode
        };
        foreach (var item in orderDto.OrderDetails)
        {
            order.AddDetail(
                item.ProductId,
                item.UnitPrice,
                item.Quantity);
        }
        return order;
    }
}
