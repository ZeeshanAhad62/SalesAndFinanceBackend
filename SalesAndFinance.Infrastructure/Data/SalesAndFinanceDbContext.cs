using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalesAndFinance.Infrastructure;

namespace SalesAndFinance.Infrastructure.Data;

public partial class SalesAndFinanceDbContext : DbContext
{
    public SalesAndFinanceDbContext()
    {
    }

    public SalesAndFinanceDbContext(DbContextOptions<SalesAndFinanceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

    public virtual DbSet<ProductsService> ProductsServices { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SalesAndFinance;user id=zeeshan;password=123qwe;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC070EEB79B9");

            entity.ToTable("CategoryProduct");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductsService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07ED8DFD99");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountType).HasMaxLength(20);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Units__3214EC075FA80DE6");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ShortName).HasMaxLength(20);
            entity.Property(e => e.UnitName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC070BA52B86");

            entity.ToTable("User");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
