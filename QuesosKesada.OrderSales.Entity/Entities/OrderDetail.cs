namespace QuesosKesada.OrderSales.Entity.Entities;
public class OrderDetail
{
    /// <summary>
    /// Representa un ítem de una orden de compra.
    /// </summary>
    /// <param name="productId"> El identificador único del producto</param>
    /// <param name="unitPrice"> El precio unitario del producto</param>
    /// <param name="quantity"> La cantidad del producto</param>
    public OrderDetail(int productId, float unitPrice, int quantity)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public int Id { get; set; }
    public int ProductId { get; set; }
    public float UnitPrice { get; set; }
    public int Quantity { get; set; } // Property public that represents the quantity of the product in the order detail
}
//Aggregate