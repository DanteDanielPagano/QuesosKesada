using QuesosKesada.OrderSales.Entity.Entities;
using QuesosKesada.OrderSales.Entity.Interfaces;

namespace QuesosKesada.OrderSales.Presenters.Implementations;
internal class CreateOrderPresenter : ICreateOrderOutputPort
{
    public int OrderId { get; private set; }

    public async Task Handle(OrderHeader orderHeader)
    {
        OrderId = orderHeader.Id;
        await Task.CompletedTask;
    }
}
