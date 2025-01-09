using System.ComponentModel.DataAnnotations;

namespace InvoicesManagmentApp.Models
{
    public class InvoiceItemDto
    {
        [Required]
    public string Service { get; set; } = "";
    [Range(1, 999999, ErrorMessage = "Unit Price is not valid!")]
    public decimal UnitPrice { get; set; }
    [Range(1, 99)]
    public int Quantity { get; set; }
}
}
