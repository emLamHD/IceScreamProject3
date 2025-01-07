using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models
{
    [Table("transactions")]
    public partial class Transaction
    {
        [Key]
        [Column("TransactionId")]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "UserId không được để trống.")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId phải lớn hơn 0.")]
        [Column("UserId")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Amount không được để trống.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount phải lớn hơn 0.")]
        [Column("Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "TransactionType không được để trống.")]
        [StringLength(50, ErrorMessage = "TransactionType không được vượt quá 50 ký tự.")]
        [Column("TransactionType")]
        public string TransactionType { get; set; } = null!;

        [DataType(DataType.DateTime, ErrorMessage = "Định dạng ngày không hợp lệ.")]
        [Column("TransactionDate")]
        public DateTime? TransactionDate { get; set; }
    }
}
