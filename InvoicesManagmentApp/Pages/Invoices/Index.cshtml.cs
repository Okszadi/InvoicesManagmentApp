using InvoicesManagmentApp.Models;
using InvoicesManagmentApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InvoicesManagmentApp.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public List<Invoice> invoiceList = new();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            invoiceList = context.Invoices.Include(i => i.InvoiceItems).OrderByDescending(i => i.Id).ToList();
        }
    }
}