using demoDataFirst.Models;
using demoDataFirst.Repositories;
using System.Collections.Generic;

namespace demoDataFirst.Services
{
    public class RecipeStepService : IRecipeStepService
    {
        private readonly IGenericRepository<RecipeStep> _recipeStepRepository;

        public RecipeStepService(IGenericRepository<RecipeStep> recipeStepRepository)
        {
            _recipeStepRepository = recipeStepRepository;
        }

        public IEnumerable<RecipeStep> GetAllRecipeSteps()
        {
            return _recipeStepRepository.GetAll();
        }

        public RecipeStep GetRecipeStepById(int id)
        {
            return _recipeStepRepository.GetById(id);
        }

        public void AddRecipeStep(RecipeStep recipeStep)
        {
            _recipeStepRepository.Add(recipeStep);
            _recipeStepRepository.Save();
        }

        public void UpdateRecipeStep(RecipeStep recipeStep)
        {
            _recipeStepRepository.Update(recipeStep);
            _recipeStepRepository.Save();
        }

        public void DeleteRecipeStep(int id)
        {
            _recipeStepRepository.Delete(id);
            _recipeStepRepository.Save();
        }
    }


}
