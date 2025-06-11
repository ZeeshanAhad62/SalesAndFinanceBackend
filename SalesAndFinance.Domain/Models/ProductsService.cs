using System;
using System.Collections.Generic;

namespace SalesAndFinance.Infrastructure;

public partial class ProductsService
{
    public int Id { get; set; }

    public int ItemType { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal PurchasePrice { get; set; }

    public int Quantity { get; set; }

    public int UnitId { get; set; }

    public string? DiscountType { get; set; }

    public int AlertQuantity { get; set; }

    public decimal? Tax { get; set; }

    public string? ProductDescription { get; set; }

    public string Image { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
