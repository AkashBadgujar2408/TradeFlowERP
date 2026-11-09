using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class SalesInvoice
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly Date { get; set; }

    public DateOnly DueDate { get; set; }

    public int CustomerId { get; set; }

    public int WarehouseId { get; set; }

    public string Status { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public decimal SubTotal { get; set; }

    public decimal DiscountTotal { get; set; }

    public decimal TaxTotal { get; set; }

    public decimal ChargesTotal { get; set; }

    public decimal GrandTotal { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<ReceiptAllocation> ReceiptAllocations { get; set; } = new List<ReceiptAllocation>();

    public virtual ICollection<SalesInvoiceCharge> SalesInvoiceCharges { get; set; } = new List<SalesInvoiceCharge>();

    public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItem>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}
