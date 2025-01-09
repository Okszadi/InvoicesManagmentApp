﻿using Microsoft.EntityFrameworkCore;

namespace InvoicesManagmentApp.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }

        public string Service { get; set; } = "";
        [Precision(16, 2)]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public int InvoiceId { get; set; }
        //public Invoice Invoice { get; set; } = null!;
    }
}

