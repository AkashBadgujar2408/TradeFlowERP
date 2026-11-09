using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class StockAdjustmentLine
{
    public int Id { get; set; }

    public int AdjustmentId { get; set; }

    public int ProductId { get; set; }

    public string Direction { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string Remarks { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual StockAdjustment Adjustment { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
