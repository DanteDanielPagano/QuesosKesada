using QuesosKesada.OrderSales.Entity.DTOs;
using QuesosKesada.OrderSales.Entity.Entities;

namespace QuesosKesada.OrderSales.Entity.Aggregate;
public class OrderAggregate : OrderHeader
{
    readonly private List<OrderDetail> _orderDetailsField = new();
    public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetailsField;
    //{
    //    get
    //    {
    //        return _orderDetailsField;
    //    }
    //}

    public void AddDetail(int productId, float unitPrice, int quantity)
    {
        //var existingOrderDetail = _orderDetailsField.
        //    FirstOrDefault(o => o.ProductId == productId);

        OrderDetail existingOrderDetail = null;

        foreach (var d in _orderDetailsField)
        {
            if (d.ProductId == productId)
            {
                existingOrderDetail = new OrderDetail(d.ProductId, d.UnitPrice, d.Quantity);
            }
        }

        if (existingOrderDetail != null)
        {
            quantity += existingOrderDetail.Quantity;
            _orderDetailsField.Remove(existingOrderDetail);
        }

        _orderDetailsField.Add(new OrderDetail(productId, unitPrice, quantity));
    }

    public static OrderAggregate From(OrderDto orderDto)
    {
        //Mapeamos el DTO en el OrderAggregate
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
