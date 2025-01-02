using demoDataFirst.Models;
using demoDataFirst.Repositories;

namespace demoDataFirst.Services
{
    public class RecipeStepService : IRecipeStepService
    {
        private readonly IGenericRepository<RecipeStep> _stepRepository;

        public RecipeStepService(IGenericRepository<RecipeStep> stepRepository)
        {
            _stepRepository = stepRepository;
        }

        public IEnumerable<RecipeStep> GetAllSteps()
        {
            return _stepRepository.GetAll();
        }

        public RecipeStep GetStepById(int id)
        {
            return _stepRepository.GetById(id);
        }

        public async Task CreateStepAsync(RecipeStep step)
        {
            await _stepRepository.AddAsync(step);
            await _stepRepository.SaveAsync();
        }

        public async Task UpdateStepAsync(RecipeStep step)
        {
            await _stepRepository.UpdateAsync(step);
        }

        public async Task DeleteStepAsync(int id)
        {
            await _stepRepository.DeleteAsync(id);
        }
    }
}
