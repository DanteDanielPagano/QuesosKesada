namespace QuesosKesada.OrderSales.Entity.DTOs;
public class OrderDetailDto
{
    public OrderDetailDto(int productId, float unitPrice, int quantity)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public int ProductId { get; }
    public float UnitPrice { get; }
    public int Quantity { get; }
}
