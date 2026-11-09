using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class Receipt
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int CustomerId { get; set; }

    public string Mode { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Notes { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<ReceiptAllocation> ReceiptAllocations { get; set; } = new List<ReceiptAllocation>();
}
