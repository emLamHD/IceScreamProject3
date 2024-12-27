using demoDataFirst.Models;

public interface IRecipeStepService
{
    IEnumerable<RecipeStep> GetAllRecipeSteps();
    RecipeStep GetRecipeStepById(int id);
    void AddRecipeStep(RecipeStep recipeStep);
    void UpdateRecipeStep(RecipeStep recipeStep);
    void DeleteRecipeStep(int id);
}