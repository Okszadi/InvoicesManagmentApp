using InvoicesManagmentApp.Models;
using InvoicesManagmentApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InvoicesManagmentApp.Pages.Invoices
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; } = new InvoiceDto();

        [BindProperty]
        public InvoiceItemDto InvoiceItemDto { get; set; } = new();

        public Invoice Invoice { get; set; } = new();


        private readonly ApplicationDbContext context;

        public EditModel(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult OnGet(int id)
        {
            var invoice = context.Invoices.Include(i => i.InvoiceItems).FirstOrDefault(i => i.Id == id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }

            Invoice = invoice;

            InvoiceDto.Number = invoice.Number;
            InvoiceDto.Status = invoice.Status;
            InvoiceDto.IssueDate = invoice.IssueDate;
            InvoiceDto.DueDate = invoice.DueDate;

            InvoiceDto.ClientName = invoice.ClientName;
            InvoiceDto.Email = invoice.Email;
            InvoiceDto.Phone = invoice.Phone;
            InvoiceDto.Address = invoice.Address;

            return Page();
        }


        public string successMessage = "";

        public IActionResult OnPost(int id)
        {
            var invoice = context.Invoices.Include(i => i.InvoiceItems).FirstOrDefault(i => i.Id == id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }

            Invoice = invoice;



            ModelState.Remove(nameof(InvoiceItemDto.Service));
            ModelState.Remove(nameof(InvoiceItemDto.Quantity));
            ModelState.Remove(nameof(InvoiceItemDto.UnitPrice));

            if (!ModelState.IsValid)
            {
                return Page();
            }


            invoice.Number = InvoiceDto.Number;
            invoice.Status = InvoiceDto.Status;
            invoice.IssueDate = InvoiceDto.IssueDate;
            invoice.DueDate = InvoiceDto.DueDate;

            invoice.ClientName = InvoiceDto.ClientName;
            invoice.Email = InvoiceDto.Email;
            invoice.Phone = InvoiceDto.Phone;
            invoice.Address = InvoiceDto.Address;

            context.SaveChanges();

            successMessage = "Invoice Updated Successfully!";

            return Page();
        }



        public IActionResult OnPostCreateItem(int id)
        {
            var invoice = context.Invoices.Include(i => i.InvoiceItems).FirstOrDefault(i => i.Id == id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }

            if (string.IsNullOrEmpty(InvoiceItemDto.Service) || InvoiceItemDto.Quantity <= 0 || InvoiceItemDto.UnitPrice <= 0)
            {
                // submitted Item is not valid
                TempData["ErrorMessage"] = "Submitted Item is not valid!";
                return RedirectToPage("/Invoices/Edit", new { id });
            }

            var invoiceItem = new InvoiceItem
            {
                Service = InvoiceItemDto.Service,
                Quantity = InvoiceItemDto.Quantity,
                UnitPrice = InvoiceItemDto.UnitPrice,
            };

            invoice.InvoiceItems.Add(invoiceItem);
            context.SaveChanges();

            return RedirectToPage("/Invoices/Edit", new { id });
        }



        public IActionResult OnGetDeleteItem(int invoiceId, int itemId)
        {
            var item = context.InvoiceItems.Find(itemId);
            if (item != null)
            {
                context.InvoiceItems.Remove(item);
                context.SaveChanges();
            }

            return RedirectToPage("/Invoices/Edit", new { id = invoiceId });
        }
    }
}