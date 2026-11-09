using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class VwProductStock
{
    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public decimal? Quantity { get; set; }
}
