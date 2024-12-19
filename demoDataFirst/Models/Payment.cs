using System;
using System.Collections.Generic;

namespace demoDataFirst.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public int? UserId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal Amount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public DateTime? TransactionDate { get; set; }

    public string? Remarks { get; set; }
}
