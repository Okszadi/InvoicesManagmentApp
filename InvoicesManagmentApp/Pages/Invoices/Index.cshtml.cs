using InvoicesManagmentApp.Models;
using InvoicesManagmentApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoicesManagmentApp.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext context;

        public List<Invoice> invoiceList = new();

        public IndexModel(ApplicationDbContext context) 
        { 
            this.context = context;
        }

        public void OnGet()
        {
            invoiceList = context.Invoices.OrderByDescending(i => i.Id).ToList();
        }
    }
}
