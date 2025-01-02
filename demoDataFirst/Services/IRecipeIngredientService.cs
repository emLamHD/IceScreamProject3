using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IRecipeIngredientService
    {
        IEnumerable<RecipeIngredient> GetAllIngredients();
        RecipeIngredient GetIngredientById(int id);
        Task CreateIngredientAsync(RecipeIngredient ingredient);
        Task UpdateIngredientAsync(RecipeIngredient ingredient);
        Task DeleteIngredientAsync(int id);
    }
}
