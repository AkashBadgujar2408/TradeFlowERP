using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class VwInvoiceBalance
{
    public int InvoiceId { get; set; }

    public decimal GrandTotal { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal? Balance { get; set; }
}
