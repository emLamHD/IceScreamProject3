using System;
using System.Collections.Generic;

namespace demoDataFirst.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? UserId { get; set; }

    public decimal Amount { get; set; }

    public string TransactionType { get; set; } = null!;

    public DateTime? TransactionDate { get; set; }
}
