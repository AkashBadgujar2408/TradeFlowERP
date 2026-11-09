using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class SalesInvoiceCharge
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual SalesInvoice Invoice { get; set; } = null!;
}
