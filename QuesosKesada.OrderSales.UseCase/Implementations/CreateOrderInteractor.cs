using QuesosKesada.OrderSales.BusinessObjects.Repositories.Interface;
using QuesosKesada.OrderSales.Entity.Aggregate;
using QuesosKesada.OrderSales.Entity.DTOs;
using QuesosKesada.OrderSales.Entity.Interfaces;

namespace QuesosKesada.OrderSales.UseCase.Implementations;
internal class CreateOrderInteractor : ICreateOrderInputPort
{
    private readonly IOrderCommandsRepository _orderCommands;
    private readonly ICreateOrderOutputPort _presenter;
    public CreateOrderInteractor(
        IOrderCommandsRepository orderCommands,
        ICreateOrderOutputPort presenter)
    {
        _orderCommands = orderCommands;
        _presenter = presenter;
    }

    public async Task Handle(OrderDto orderDto)
    {
        if (orderDto == null)
        {
            throw new ArgumentNullException(nameof(orderDto));
        }


        var orderAggregate = OrderAggregate.From(orderDto);
        await _orderCommands.Create(orderAggregate);
        await _presenter.Handle(orderAggregate);
    }
}
