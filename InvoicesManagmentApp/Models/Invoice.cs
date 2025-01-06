using Microsoft.EntityFrameworkCore;

namespace InvoicesManagmentApp.Models
{
    public class Invoice
    {
        //For invoices
        public int Id { get; set; }
        public string Number { get; set; } = "";
        public string Status { get; set; } = "";
        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }

        //For service details
        public string Service { get; set; } = "";
        [Precision(16,2)]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        //For client details
        public string ClientName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
