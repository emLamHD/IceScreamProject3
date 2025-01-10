using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models;
[Table("products")]
public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự")]
    public string Name { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
    [StringLength(50, ErrorMessage = "Danh mục sản phẩm không được vượt quá 50 ký tự")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "Giá bán lẻ không được để trống")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá bán lẻ phải lớn hơn 0")]
    public decimal RetailPrice { get; set; }

    [Required(ErrorMessage = "Giá bán buôn không được để trống")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá bán buôn phải lớn hơn 0")]
    public decimal WholesalePrice { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho phải lớn hơn hoặc bằng 0")]
    public int? Stock { get; set; }

    public int? CreatedBy { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Định dạng thời gian không hợp lệ")]
    public DateTime? CreatedAt { get; set; }

    // Thêm navigation property
    public ICollection<ProductImage> ProductImages { get; set; }
}
