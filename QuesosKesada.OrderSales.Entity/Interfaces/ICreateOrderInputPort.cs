using QuesosKesada.OrderSales.Entity.DTOs;

namespace QuesosKesada.OrderSales.Entity.Interfaces;
public interface ICreateOrderInputPort
{
    Task Handle(OrderDto orderDto);
}
