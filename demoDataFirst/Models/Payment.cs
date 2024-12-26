using System;
using System.ComponentModel.DataAnnotations;

namespace demoDataFirst.Models;

public partial class Payment
{
    [Key]
    public int PaymentId { get; set; }

    [Required(ErrorMessage = "OrderId is required.")]
    public int? OrderId { get; set; }

    [Required(ErrorMessage = "UserId is required.")]
    public int? UserId { get; set; }

    [Required(ErrorMessage = "PaymentMethod is required.")]
    [StringLength(50, ErrorMessage = "PaymentMethod cannot exceed 50 characters.")]
    public string PaymentMethod { get; set; } = null!;

    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "PaymentStatus is required.")]
    [StringLength(20, ErrorMessage = "PaymentStatus cannot exceed 20 characters.")]
    public string PaymentStatus { get; set; } = null!;

    [DataType(DataType.DateTime)]
    public DateTime? TransactionDate { get; set; }

    [StringLength(200, ErrorMessage = "Remarks cannot exceed 200 characters.")]
    public string? Remarks { get; set; }
}
