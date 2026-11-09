using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class EmployeeExperience
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Company { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
