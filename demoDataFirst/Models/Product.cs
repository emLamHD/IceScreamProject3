using System;
using System.ComponentModel.DataAnnotations;

namespace demoDataFirst.Models
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name không được để trống")]
        [StringLength(100, ErrorMessage = "Name không được vượt quá 100 ký tự")]
        public string Name { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Description không được vượt quá 500 ký tự")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category không được để trống")]
        [StringLength(50, ErrorMessage = "Category không được vượt quá 50 ký tự")]
        public string Category { get; set; } = null!;

        [Required(ErrorMessage = "RetailPrice không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "RetailPrice phải lớn hơn 0")]
        public decimal RetailPrice { get; set; }

        [Required(ErrorMessage = "WholesalePrice không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "WholesalePrice phải lớn hơn 0")]
        public decimal WholesalePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock phải lớn hơn hoặc bằng 0")]
        public int? Stock { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CreatedBy phải lớn hơn 0")]
        public int? CreatedBy { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Ngày không hợp lệ")]
        public DateTime? CreatedAt { get; set; }
    }
}
