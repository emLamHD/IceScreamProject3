using System;
using System.ComponentModel.DataAnnotations;

namespace demoDataFirst.Models
{
    public partial class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "UserId không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId phải lớn hơn 0")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Amount không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount phải lớn hơn 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "TransactionType không được để trống")]
        [StringLength(50, ErrorMessage = "TransactionType không được vượt quá 50 ký tự")]
        public string TransactionType { get; set; } = null!;

        [DataType(DataType.DateTime, ErrorMessage = "Ngày không hợp lệ")]
        public DateTime? TransactionDate { get; set; }
    }
}
