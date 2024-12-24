using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoDataFirst.Models
{
    [Table("recipe_ingredients")]
    public partial class RecipeIngredient
    {
        [Key]
        [Column("IngredientID")]
        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        [Column("ProductID")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Ingredient name is required.")]
        [StringLength(100, ErrorMessage = "Ingredient name cannot exceed 100 characters.")]
        [Column("IngredientName")]
        public string IngredientName { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required.")]
        [StringLength(50, ErrorMessage = "Quantity cannot exceed 50 characters.")]
        [Column("Quantity")]
        public string Quantity { get; set; } = null!;

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(20, ErrorMessage = "Unit cannot exceed 20 characters.")]
        [Column("Unit")]
        public string Unit { get; set; } = null!;
    }
}
