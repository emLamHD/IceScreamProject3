using demoDataFirst.Models;
using demoDataFirst.Repositories;

namespace demoDataFirst.Services
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IGenericRepository<RecipeIngredient> _ingredientRepository;

        public RecipeIngredientService(IGenericRepository<RecipeIngredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<RecipeIngredient> GetAllIngredients()
        {
            return _ingredientRepository.GetAll();
        }

        public RecipeIngredient GetIngredientById(int id)
        {
            return _ingredientRepository.GetById(id);
        }

        public async Task CreateIngredientAsync(RecipeIngredient ingredient)
        {
            await _ingredientRepository.AddAsync(ingredient);
            await _ingredientRepository.SaveAsync();
        }

        public async Task UpdateIngredientAsync(RecipeIngredient ingredient)
        {
            await _ingredientRepository.UpdateAsync(ingredient);
        }

        public async Task DeleteIngredientAsync(int id)
        {
            await _ingredientRepository.DeleteAsync(id);
        }
    }
}
