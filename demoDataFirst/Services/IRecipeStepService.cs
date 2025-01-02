using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IRecipeStepService
    {
        IEnumerable<RecipeStep> GetAllSteps();
        RecipeStep GetStepById(int id);
        Task CreateStepAsync(RecipeStep step);
        Task UpdateStepAsync(RecipeStep step);
        Task DeleteStepAsync(int id);
    }
}
