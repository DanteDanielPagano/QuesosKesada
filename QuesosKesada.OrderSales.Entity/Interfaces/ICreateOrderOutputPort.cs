using QuesosKesada.OrderSales.Entity.Entities;

namespace QuesosKesada.OrderSales.Entity.Interfaces;
public interface ICreateOrderOutputPort
{
    int OrderId { get; }

    Task Handle(OrderHeader orderHeader);
}
