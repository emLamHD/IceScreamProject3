using System;
using System.Collections.Generic;

namespace demoDataFirst.Models;

public partial class RecipeIngredient
{
    public int IngredientId { get; set; }

    public int? ProductId { get; set; }

    public string IngredientName { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public string Unit { get; set; } = null!;
}
