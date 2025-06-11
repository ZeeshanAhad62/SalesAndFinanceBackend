using System;
using System.Collections.Generic;

namespace SalesAndFinance.Infrastructure;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? ContactNumber { get; set; }

    public string PasswordHash { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedAt { get; set; }
}
