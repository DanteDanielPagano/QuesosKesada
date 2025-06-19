using QuesosKesada.OrderSales.Entity.Aggregate;

namespace QuesosKesada.OrderSales.BusinessObjects.Repositories.Interface;
public interface IOrderCommandsRepository
{
    Task Create(OrderAggregate orderAggregate);
    //Task SoftDelete(int orderId);
    //Task HardDelete(int orderId);

}
