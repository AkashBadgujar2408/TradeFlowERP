using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class PurchaseOrder
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly Date { get; set; }

    public DateOnly? ExpectedDate { get; set; }

    public int SupplierId { get; set; }

    public int WarehouseId { get; set; }

    public string Status { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public decimal SubTotal { get; set; }

    public decimal TaxTotal { get; set; }

    public decimal GrandTotal { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
