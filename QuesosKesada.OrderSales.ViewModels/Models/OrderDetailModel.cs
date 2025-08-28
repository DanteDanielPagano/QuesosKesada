using System.ComponentModel.DataAnnotations;

namespace QuesosKesada.OrderSales.ViewModels.Models;
public class OrderDetailModel
{
    [Required]
    public int ProductId { get; set; }

    [Range(0.0, 10000.0, ErrorMessage = "El presio debe ser mayor que 0 y menor 10000")]
    public float UnitPrice { get; set; }

    [Range(1, 99, ErrorMessage = "La cantidad debe estar entre 1 y 99.")]
    public int Quantity { get; set; }
}
