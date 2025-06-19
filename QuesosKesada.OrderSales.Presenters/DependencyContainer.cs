
using QuesosKesada.OrderSales.Entity.Interfaces;
using QuesosKesada.OrderSales.Presenters.Implementations;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddOrderPresenterSevices(this IServiceCollection services)
    {
        services.AddTransient<ICreateOrderOutputPort, CreateOrderPresenter>();

        return services;

        //Explicar tipos de servicios.
    }
}
