using System;
using System.Collections.Generic;

namespace demoDataFirst.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public decimal RetailPrice { get; set; }

    public decimal WholesalePrice { get; set; }

    public int? Stock { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }
}
