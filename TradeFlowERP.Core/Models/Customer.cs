using System;
using System.Collections.Generic;

namespace TradeFlowERP.Core.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Gstin { get; set; } = null!;

    public decimal CreditLimit { get; set; }

    public string BillingLine1 { get; set; } = null!;

    public string BillingCity { get; set; } = null!;

    public string BillingState { get; set; } = null!;

    public string BillingPincode { get; set; } = null!;

    public bool SameAsBilling { get; set; }

    public string ShippingLine1 { get; set; } = null!;

    public string ShippingCity { get; set; } = null!;

    public string ShippingState { get; set; } = null!;

    public string ShippingPincode { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();
}
