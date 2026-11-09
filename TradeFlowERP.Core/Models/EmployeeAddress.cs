using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class EmployeeAddress
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Type { get; set; } = null!;

    public string Line1 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
