using InvoicesManagmentApp.Models;
using InvoicesManagmentApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoicesManagmentApp.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; } = new();

        [BindProperty]
        public InvoiceItemDto InvoiceItemDto { get; set; } = new();


        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var invoiceItem = new InvoiceItem
            {
                Service = InvoiceItemDto.Service,
                UnitPrice = InvoiceItemDto.UnitPrice,
                Quantity = InvoiceItemDto.Quantity,
            };

            var invoice = new Invoice
            {
                Number = InvoiceDto.Number,
                Status = InvoiceDto.Status,
                IssueDate = InvoiceDto.IssueDate,
                DueDate = InvoiceDto.DueDate,
                ClientName = InvoiceDto.ClientName,
                Email = InvoiceDto.Email,
                Phone = InvoiceDto.Phone,
                Address = InvoiceDto.Address,
                InvoiceItems = new List<InvoiceItem>() // Initialize the collection
            };

            invoice.InvoiceItems.Add(invoiceItem);

            context.Invoices.Add(invoice);
            context.SaveChanges();

            return RedirectToPage("/Invoices/Edit", new { id = invoice.Id });
        }
    }
}
