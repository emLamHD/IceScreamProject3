using System;
using System.ComponentModel.DataAnnotations;

namespace demoDataFirst.Models;

public partial class RecipeIngredient
{
    [Key]
    public int IngredientId { get; set; }

    [Required(ErrorMessage = "ProductId không được để trống")]
    [Range(1, int.MaxValue, ErrorMessage = "ProductId phải lớn hơn 0")]
    public int? ProductId { get; set; }

    [Required(ErrorMessage = "Tên nguyên liệu không được để trống")]
    [StringLength(100, ErrorMessage = "Tên nguyên liệu không được vượt quá 100 ký tự")]
    public string IngredientName { get; set; } = null!;

    [Required(ErrorMessage = "Số lượng không được để trống")]
    [StringLength(50, ErrorMessage = "Số lượng không được vượt quá 50 ký tự")]
    public string Quantity { get; set; } = null!;

    [Required(ErrorMessage = "Đơn vị tính không được để trống")]
    [StringLength(20, ErrorMessage = "Đơn vị tính không được vượt quá 20 ký tự")]
    public string Unit { get; set; } = null!;
}
