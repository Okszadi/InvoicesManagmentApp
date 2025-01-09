using System.ComponentModel.DataAnnotations;

namespace InvoicesManagmentApp.Models
{
    public class InvoiceDto
    {
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = ""; // Paid or Pending
        public DateOnly? IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }



        // client details
        [Required(ErrorMessage = "Client Name is required)")]
        public string ClientName { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Phone]
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}

