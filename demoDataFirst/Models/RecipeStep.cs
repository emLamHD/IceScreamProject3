using System;
using System.Collections.Generic;

namespace demoDataFirst.Models;

public partial class RecipeStep
{
    public int StepId { get; set; }

    public int? ProductId { get; set; }

    public int StepNumber { get; set; }

    public string Description { get; set; } = null!;

    public int Duration { get; set; }

    public string? ImagePath { get; set; }

    public DateTime? CreatedAt { get; set; }
}
