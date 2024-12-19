using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models
{
    [Table("orders")]
    public partial class Order
    {
        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }

        [Column("UserID")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0.")]
        [Column("TotalAmount")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        [StringLength(20, ErrorMessage = "Payment method cannot exceed 20 characters.")]
        [Column("PaymentMethod")]
        public string PaymentMethod { get; set; } = null!;

        [Required(ErrorMessage = "Order date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid order date format.")]
        [Column("OrderDate")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        [RegularExpression("^(Pending|Completed|Canceled)$", ErrorMessage = "Status must be 'Pending', 'Completed', or 'Canceled'.")]
        [Column("Status")]
        public string? Status { get; set; }
    }
}
