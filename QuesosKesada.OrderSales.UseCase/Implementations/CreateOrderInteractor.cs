using QuesosKesada.OrderSales.BusinessObjects.Repositories.Interface;
using QuesosKesada.OrderSales.Entity.Aggregate;
using QuesosKesada.OrderSales.Entity.DTOs;
using QuesosKesada.OrderSales.Entity.Interfaces;
using QuesosKesada.Shared.Guards;

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
        ArgumentNullException.ThrowIfNull(orderDto);

        Guard.Against(orderDto.ShippingAddress, "Dirección de envío")
            .NotNullOrEmpty("El campo Dirección es obligatorio.")
            .MaxLength(25, "El campo Dirección debe contener como máximo 25 caracteres.");

        var orderAggregate = OrderAggregate.From(orderDto);
        await _orderCommands.Create(orderAggregate);
        await _presenter.Handle(orderAggregate);
    }
}
