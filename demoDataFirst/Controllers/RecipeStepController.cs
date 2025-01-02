using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeStepController : ControllerBase
    {
        private readonly IRecipeStepService _recipeStepService;

        public RecipeStepController(IRecipeStepService recipeStepService)
        {
            _recipeStepService = recipeStepService;
        }

        [HttpGet]
        public IActionResult GetAllSteps()
        {
            var steps = _recipeStepService.GetAllSteps();
            return Ok(steps);
        }

        [HttpGet("{id}")]
        public IActionResult GetStepById(int id)
        {
            var step = _recipeStepService.GetStepById(id);
            if (step == null) return NotFound();
            return Ok(step);
        }

        [HttpPost]
        public async Task<IActionResult> AddStep(RecipeStep step)
        {
            try
            {
                await _recipeStepService.CreateStepAsync(step);
                return CreatedAtAction(nameof(GetStepById), new { id = step.StepId }, step);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStep(int id, RecipeStep step)
        {
            if (id != step.StepId) return BadRequest("Step ID không khớp.");

            await _recipeStepService.UpdateStepAsync(step);
            return Ok("Cập nhật thành công.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStep(int id)
        {
            await _recipeStepService.DeleteStepAsync(id);
            return Ok("Xóa thành công.");
        }
    }
}
