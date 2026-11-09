using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TradeFlowERP.Core.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

    public virtual DbSet<EmployeeExperience> EmployeeExperiences { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<ReceiptAllocation> ReceiptAllocations { get; set; }

    public virtual DbSet<SalesInvoice> SalesInvoices { get; set; }

    public virtual DbSet<SalesInvoiceCharge> SalesInvoiceCharges { get; set; }

    public virtual DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }

    public virtual DbSet<StockAdjustment> StockAdjustments { get; set; }

    public virtual DbSet<StockAdjustmentLine> StockAdjustmentLines { get; set; }

    public virtual DbSet<StockMovement> StockMovements { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TaxRate> TaxRates { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwInvoiceBalance> VwInvoiceBalances { get; set; }

    public virtual DbSet<VwProductStock> VwProductStocks { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.Code, "UQ_Categories_Code").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Categories_CreatedAt");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValue("", "DF_Categories_Description");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Categories_IsActive");
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Categories_UpdatedAt");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.Code, "UQ_Customers_Code").IsUnique();

            entity.HasIndex(e => e.Email, "UQ_Customers_Email").IsUnique();

            entity.Property(e => e.BillingCity).HasMaxLength(60);
            entity.Property(e => e.BillingLine1).HasMaxLength(200);
            entity.Property(e => e.BillingPincode)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.BillingState).HasMaxLength(60);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Customers_CreatedAt");
            entity.Property(e => e.CreditLimit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Gstin)
                .HasMaxLength(15)
                .HasDefaultValue("", "DF_Customers_Gstin");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Customers_IsActive");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.SameAsBilling).HasDefaultValue(true, "DF_Customers_SameAsBilling");
            entity.Property(e => e.ShippingCity).HasMaxLength(60);
            entity.Property(e => e.ShippingLine1).HasMaxLength(200);
            entity.Property(e => e.ShippingPincode)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.ShippingState).HasMaxLength(60);
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Customers_UpdatedAt");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.Code, "UQ_Employees_Code").IsUnique();

            entity.HasIndex(e => e.Email, "UQ_Employees_Email").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Employees_CreatedAt");
            entity.Property(e => e.Department).HasMaxLength(30);
            entity.Property(e => e.Designation).HasMaxLength(60);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Employees_IsActive");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Employees_UpdatedAt");
        });

        modelBuilder.Entity<EmployeeAddress>(entity =>
        {
            entity.HasIndex(e => new { e.EmployeeId, e.Type }, "UQ_EmployeeAddresses_Type").IsUnique();

            entity.Property(e => e.City).HasMaxLength(60);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_EmployeeAddresses_CreatedAt");
            entity.Property(e => e.Line1).HasMaxLength(200);
            entity.Property(e => e.Pincode)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.State).HasMaxLength(60);
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_EmployeeAddresses_UpdatedAt");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeAddresses)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeAddresses_Employees");
        });

        modelBuilder.Entity<EmployeeExperience>(entity =>
        {
            entity.ToTable("EmployeeExperience");

            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_EmployeeExperience_CreatedAt");
            entity.Property(e => e.Role).HasMaxLength(60);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_EmployeeExperience_UpdatedAt");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeExperiences)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeExperience_Employees");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.HasIndex(e => e.Sku, "UQ_Products_Sku").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Products_CreatedAt");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasDefaultValue("", "DF_Products_Description");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Products_IsActive");
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReorderLevel).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sku).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Products_UpdatedAt");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.TaxRate).WithMany(p => p.Products)
                .HasForeignKey(d => d.TaxRateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_TaxRates");

            entity.HasOne(d => d.Unit).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Units");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasIndex(e => new { e.SupplierId, e.Date }, "IX_PurchaseOrders_Supplier_Date");

            entity.HasIndex(e => e.Number, "UQ_PurchaseOrders_Number").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_PurchaseOrders_CreatedAt");
            entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasDefaultValue("", "DF_PurchaseOrders_Notes");
            entity.Property(e => e.Number).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_PurchaseOrders_UpdatedAt");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrders_Suppliers");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrders_Warehouses");
        });

        modelBuilder.Entity<PurchaseOrderLine>(entity =>
        {
            entity.HasIndex(e => e.PurchaseOrderId, "IX_PurchaseOrderLines_PurchaseOrderId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_PurchaseOrderLines_CreatedAt");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_PurchaseOrderLines_UpdatedAt");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrderLines_Products");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.PurchaseOrderId)
                .HasConstraintName("FK_PurchaseOrderLines_PurchaseOrders");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasIndex(e => e.Number, "UQ_Receipts_Number").IsUnique();

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Receipts_CreatedAt");
            entity.Property(e => e.Mode).HasMaxLength(20);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasDefaultValue("", "DF_Receipts_Notes");
            entity.Property(e => e.Number).HasMaxLength(20);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .HasDefaultValue("", "DF_Receipts_Reference");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Receipts_UpdatedAt");

            entity.HasOne(d => d.Customer).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipts_Customers");
        });

        modelBuilder.Entity<ReceiptAllocation>(entity =>
        {
            entity.HasIndex(e => e.InvoiceId, "IX_ReceiptAllocations_InvoiceId");

            entity.HasIndex(e => new { e.ReceiptId, e.InvoiceId }, "UQ_ReceiptAllocations").IsUnique();

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_ReceiptAllocations_CreatedAt");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_ReceiptAllocations_UpdatedAt");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ReceiptAllocations)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceiptAllocations_SalesInvoices");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ReceiptAllocations)
                .HasForeignKey(d => d.ReceiptId)
                .HasConstraintName("FK_ReceiptAllocations_Receipts");
        });

        modelBuilder.Entity<SalesInvoice>(entity =>
        {
            entity.HasIndex(e => new { e.CustomerId, e.Date }, "IX_SalesInvoices_Customer_Date");

            entity.HasIndex(e => new { e.Status, e.Date }, "IX_SalesInvoices_Status_Date");

            entity.HasIndex(e => e.Number, "UQ_SalesInvoices_Number").IsUnique();

            entity.Property(e => e.ChargesTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_SalesInvoices_CreatedAt");
            entity.Property(e => e.DiscountTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .HasDefaultValue("", "DF_SalesInvoices_Notes");
            entity.Property(e => e.Number).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_SalesInvoices_UpdatedAt");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesInvoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesInvoices_Customers");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.SalesInvoices)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesInvoices_Warehouses");
        });

        modelBuilder.Entity<SalesInvoiceCharge>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_SalesInvoiceCharges_CreatedAt");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_SalesInvoiceCharges_UpdatedAt");

            entity.HasOne(d => d.Invoice).WithMany(p => p.SalesInvoiceCharges)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_SalesInvoiceCharges_SalesInvoices");
        });

        modelBuilder.Entity<SalesInvoiceItem>(entity =>
        {
            entity.HasIndex(e => e.InvoiceId, "IX_SalesInvoiceItems_InvoiceId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_SalesInvoiceItems_CreatedAt");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_SalesInvoiceItems_UpdatedAt");

            entity.HasOne(d => d.Invoice).WithMany(p => p.SalesInvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_SalesInvoiceItems_SalesInvoices");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesInvoiceItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesInvoiceItems_Products");
        });

        modelBuilder.Entity<StockAdjustment>(entity =>
        {
            entity.HasIndex(e => e.Number, "UQ_StockAdjustments_Number").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_StockAdjustments_CreatedAt");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasDefaultValue("", "DF_StockAdjustments_Notes");
            entity.Property(e => e.Number).HasMaxLength(20);
            entity.Property(e => e.Reason).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_StockAdjustments_UpdatedAt");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.StockAdjustments)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockAdjustments_Warehouses");
        });

        modelBuilder.Entity<StockAdjustmentLine>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_StockAdjustmentLines_CreatedAt");
            entity.Property(e => e.Direction).HasMaxLength(3);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasDefaultValue("", "DF_StockAdjustmentLines_Remarks");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_StockAdjustmentLines_UpdatedAt");

            entity.HasOne(d => d.Adjustment).WithMany(p => p.StockAdjustmentLines)
                .HasForeignKey(d => d.AdjustmentId)
                .HasConstraintName("FK_StockAdjustmentLines_StockAdjustments");

            entity.HasOne(d => d.Product).WithMany(p => p.StockAdjustmentLines)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockAdjustmentLines_Products");
        });

        modelBuilder.Entity<StockMovement>(entity =>
        {
            entity.HasIndex(e => new { e.ProductId, e.WarehouseId }, "IX_StockMovements_Product_Warehouse");

            entity.HasIndex(e => new { e.SourceType, e.SourceId }, "IX_StockMovements_Source");

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_StockMovements_CreatedAt");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SourceNumber).HasMaxLength(20);
            entity.Property(e => e.SourceType).HasMaxLength(3);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_StockMovements_UpdatedAt");

            entity.HasOne(d => d.Product).WithMany(p => p.StockMovements)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockMovements_Products");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.StockMovements)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockMovements_Warehouses");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.Code, "UQ_Suppliers_Code").IsUnique();

            entity.Property(e => e.City).HasMaxLength(60);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Suppliers_CreatedAt");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Suppliers_IsActive");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PaymentTermsDays).HasDefaultValue(30, "DF_Suppliers_Terms");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Suppliers_UpdatedAt");
        });

        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_TaxRates_Name").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_TaxRates_CreatedAt");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasDefaultValue("", "DF_TaxRates_Description");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_TaxRates_IsActive");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.RatePercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_TaxRates_UpdatedAt");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasIndex(e => e.Code, "UQ_Units_Code").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Units_CreatedAt");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Units_UpdatedAt");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Username, "UQ_Users_Username").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Users_CreatedAt");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Users_IsActive");
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Users_UpdatedAt");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<VwInvoiceBalance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_InvoiceBalance");

            entity.Property(e => e.Balance).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VwProductStock>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProductStock");

            entity.Property(e => e.Quantity).HasColumnType("decimal(38, 3)");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasIndex(e => e.Code, "UQ_Warehouses_Code").IsUnique();

            entity.Property(e => e.City).HasMaxLength(60);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Warehouses_CreatedAt");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Warehouses_IsActive");
            entity.Property(e => e.ManagerName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())", "DF_Warehouses_UpdatedAt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
