using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class ReceiptAllocation
{
    public int Id { get; set; }

    public int ReceiptId { get; set; }

    public int InvoiceId { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual SalesInvoice Invoice { get; set; } = null!;

    public virtual Receipt Receipt { get; set; } = null!;
}
