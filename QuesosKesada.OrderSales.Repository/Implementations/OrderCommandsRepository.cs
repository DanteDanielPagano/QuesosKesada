using LiteDB;
using QuesosKesada.OrderSales.BusinessObjects.Repositories.Interface;
using QuesosKesada.OrderSales.Entity.Aggregate;
using QuesosKesada.OrderSales.Entity.Entities;

namespace QuesosKesada.OrderSales.Repository.Implementations;
internal class OrderCommandsRepository : IOrderCommandsRepository
{
    private const string COLLECTION_ORDERS_HEADER = "ordersheaders";
    private const string COLLECTION_ORDERS_DETAIL = "ordersdetails";

    private const string COLLECTION_ORDERS = "orders";

    private const string DB_PATH = "QuesosKesadas.db";

    private readonly ILiteCollection<OrderHeader> _orderHeaderCollection;
    private readonly ILiteCollection<OrderDetail> _orderDetailCollection;
    private readonly ILiteCollection<Order> _orderCollection;

    private LiteDatabase _db;
    public OrderCommandsRepository()
    {
        _db = new LiteDatabase(DB_PATH);
        _orderHeaderCollection = _db.GetCollection<OrderHeader>(COLLECTION_ORDERS_HEADER);
        _orderDetailCollection = _db.GetCollection<OrderDetail>(COLLECTION_ORDERS_DETAIL);
        _orderCollection = _db.GetCollection<Order>(COLLECTION_ORDERS);
    }
    public Task Create(OrderAggregate orderAggregate,
        CancellationToken cancellationToken)
    {
        // Lanzo una Excepcón si se cancelo por medio del token.
        cancellationToken.ThrowIfCancellationRequested();

        // -------------------------------------------
        // Estructura SQL
        _orderHeaderCollection.Insert(orderAggregate);

        foreach (var detail in orderAggregate.OrderDetails)
        {
            detail.IdOrderHeader = orderAggregate.Id;
            _orderDetailCollection.Insert(detail);
        }
        //--------------------------------------------

        //--------------------------------------------
        // Para Estructura JSon
        Order order = new()
        {
            CustomerId = orderAggregate.CustomerId,
            ShippingAddress = orderAggregate.ShippingAddress,
            ShippingCity = orderAggregate.ShippingCity,
            ShippingCountry = orderAggregate.ShippingCountry,
            ShippingPostalCode = orderAggregate.ShippingPostalCode,
            Details = orderAggregate.OrderDetails.ToList(),
        };

        _orderCollection.Insert(order);
        //--------------------------------------------

        return Task.CompletedTask;
    }

    private class Order() : OrderHeader
    {
        public List<OrderDetail> Details { get; set; }
    }
}
