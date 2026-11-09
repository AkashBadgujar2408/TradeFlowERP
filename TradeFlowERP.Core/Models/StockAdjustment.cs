using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class StockAdjustment
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int WarehouseId { get; set; }

    public string Reason { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<StockAdjustmentLine> StockAdjustmentLines { get; set; } = new List<StockAdjustmentLine>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}
