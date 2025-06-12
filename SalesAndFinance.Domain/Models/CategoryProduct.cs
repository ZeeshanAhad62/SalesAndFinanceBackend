using System;
using System.Collections.Generic;

namespace SalesAndFinance.Infrastructure;

public partial class CategoryProduct
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public int? TotalProducts { get; set; }
}
