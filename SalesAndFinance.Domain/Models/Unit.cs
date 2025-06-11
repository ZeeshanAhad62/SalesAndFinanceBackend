using System;
using System.Collections.Generic;

namespace SalesAndFinance.Infrastructure;

public partial class Unit
{
    public int Id { get; set; }

    public string UnitName { get; set; } = null!;

    public string? ShortName { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public int? ModifiedBy { get; set; }
}
