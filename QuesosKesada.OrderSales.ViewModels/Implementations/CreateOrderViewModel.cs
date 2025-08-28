using QuesosKesada.OrderSales.Entity.DTOs;
using QuesosKesada.OrderSales.Entity.Interfaces;
using QuesosKesada.OrderSales.ViewModels.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuesosKesada.OrderSales.ViewModels.Implementations;
public class CreateOrderViewModel : INotifyPropertyChanged
{
    private readonly ICreateOrderInputPort _inputPort;
    private readonly ICreateOrderOutputPort _outputPort;

    public CreateOrderViewModel(ICreateOrderInputPort inputPort,
        ICreateOrderOutputPort outputPort)
    {
        _inputPort = inputPort;
        _outputPort = outputPort;

        Order = new OrderModel();
    }

    public OrderModel Order { get; private set; }


    private string? _message;

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChange([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChange();
        }
    }

    public async Task SaveAsync()
    {
        var dto = new OrderDto(
            Order.CustomerId,
            Order.ShippingAddress,
            Order.ShippingCity,
            Order.ShippingCountry,
            Order.ShippingPostalCode,
            Order.OrderDetails.Select(detail => new OrderDetailDto
            (detail.ProductId,
            detail.UnitPrice,
            detail.Quantity)).ToList());
        await _inputPort.Handle(dto);

        Message = $"Orden creada correctamente con el ID: {_outputPort.OrderId}";

        Order = new OrderModel();
        OnPropertyChange(nameof(Order));

    }
}
