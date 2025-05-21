
using QuesosKesada.OrderSales.Entity.Interfaces;
using QuesosKesada.OrderSales.UseCase.Implementations;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddOrderUseCaseSevices(this IServiceCollection services)
    {
        services.AddTransient<ICreateOrderInputPort, CreateOrderInteractor>();

        return services;

        //Explicar tipos de servicios.
    }
}
