using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class TaxRate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal RatePercent { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
