using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public decimal Salary { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<EmployeeAddress> EmployeeAddresses { get; set; } = new List<EmployeeAddress>();

    public virtual ICollection<EmployeeExperience> EmployeeExperiences { get; set; } = new List<EmployeeExperience>();
}
