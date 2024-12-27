using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IRecipeIngredientService
    {
        IEnumerable<RecipeIngredient> GetAll();
        RecipeIngredient GetById(int id);
        void Add(RecipeIngredient recipeIngredient);
        void Update(RecipeIngredient recipeIngredient);
        void Delete(int id);
    }
}
