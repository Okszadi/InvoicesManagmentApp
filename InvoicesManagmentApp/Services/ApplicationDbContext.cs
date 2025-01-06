using InvoicesManagmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicesManagmentApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Invoice> Invoices { get; set; } = null!;
    }
}
