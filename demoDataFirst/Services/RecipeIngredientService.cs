using demoDataFirst.Models;
using demoDataFirst.Repositories;

namespace demoDataFirst.Services
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IGenericRepository<RecipeIngredient> _repository;

        public RecipeIngredientService(IGenericRepository<RecipeIngredient> repository)
        {
            _repository = repository;
        }

        public IEnumerable<RecipeIngredient> GetAll()
        {
            return _repository.GetAll();
        }

        public RecipeIngredient GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(RecipeIngredient recipeIngredient)
        {
            _repository.Add(recipeIngredient);
            _repository.Save();
        }

        public void Update(RecipeIngredient recipeIngredient)
        {
            _repository.Update(recipeIngredient);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
