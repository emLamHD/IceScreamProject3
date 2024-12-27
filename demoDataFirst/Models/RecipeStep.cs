using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models
{
    [Table("recipe_steps")]
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

        [Required(ErrorMessage = "Description không được để trống")]
        [StringLength(500, ErrorMessage = "Description không được vượt quá 500 ký tự")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Duration không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration phải lớn hơn 0")]
        public int Duration { get; set; }

        [StringLength(255, ErrorMessage = "ImagePath không được vượt quá 255 ký tự")]
        public string? ImagePath { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Ngày không hợp lệ")]
        public DateTime? CreatedAt { get; set; }
    }
}
