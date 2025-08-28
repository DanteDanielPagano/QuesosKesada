using LiteDB;
using QuesosKesada.OrderSales.Entity.Entities;

namespace QuesosKesada.OrderSales.Repository;
public static class LiteDBMapperConfig
{
    private static bool _initialized;

    public static void Initialized()
    {
        if (_initialized)
            return;

        _initialized = true;
        var mapper = BsonMapper.Global;
        mapper.EnumAsInteger = true;

        mapper.Entity<OrderHeader>().Id(x => x.Id, autoId: true);
        mapper.Entity<OrderDetail>().Id(x => x.Id, autoId: true);
    }
}
