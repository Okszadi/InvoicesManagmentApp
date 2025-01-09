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
        public List<InvoiceItem> InvoiceItems { get; set; } = new();

        //For client details
        public string ClientName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
