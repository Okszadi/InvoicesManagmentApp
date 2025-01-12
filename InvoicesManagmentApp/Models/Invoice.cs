using Microsoft.EntityFrameworkCore;

namespace InvoicesManagmentApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}

