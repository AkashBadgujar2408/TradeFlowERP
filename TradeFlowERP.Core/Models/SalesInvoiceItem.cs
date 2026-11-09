using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class SalesInvoiceItem
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Rate { get; set; }

    public decimal DiscountPercent { get; set; }

    public decimal TaxPercent { get; set; }

    public decimal Amount { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal Total { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual SalesInvoice Invoice { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
