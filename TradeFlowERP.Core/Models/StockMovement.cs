using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class StockMovement
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public decimal Quantity { get; set; }

    public string SourceType { get; set; } = null!;

    public int SourceId { get; set; }

    public string SourceNumber { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
