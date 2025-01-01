using System;
using System.ComponentModel.DataAnnotations;

namespace demoDataFirst.Models;

public partial class RecipeStep
{
    [Key]
    public int StepId { get; set; }

    [Required(ErrorMessage = "ProductId không được để trống")]
    [Range(1, int.MaxValue, ErrorMessage = "ProductId phải lớn hơn 0")]
    public int? ProductId { get; set; }

    [Required(ErrorMessage = "StepNumber không được để trống")]
    [Range(1, int.MaxValue, ErrorMessage = "StepNumber phải lớn hơn 0")]
    public int StepNumber { get; set; }

    [Required(ErrorMessage = "Mô tả không được để trống")]
    [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Thời gian không được để trống")]
    [Range(1, int.MaxValue, ErrorMessage = "Thời gian phải lớn hơn 0")]
    public int Duration { get; set; }

    [StringLength(200, ErrorMessage = "Đường dẫn hình ảnh không được vượt quá 200 ký tự")]
    public string? ImagePath { get; set; }

    public DateTime? CreatedAt { get; set; }
}
