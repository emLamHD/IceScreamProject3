using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<RecipeStep>> GetAllRecipeSteps()
        {
            var recipeSteps = _recipeStepService.GetAllRecipeSteps();
            return Ok(recipeSteps);
        }

        [HttpGet("{id}")]
        public ActionResult<RecipeStep> GetRecipeStepById(int id)
        {
            var recipeStep = _recipeStepService.GetRecipeStepById(id);
            if (recipeStep == null)
            {
                return NotFound();
            }
            return Ok(recipeStep);
        }

        [HttpPost]
        public ActionResult AddRecipeStep([FromBody] RecipeStep recipeStep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _recipeStepService.AddRecipeStep(recipeStep);
            return CreatedAtAction(nameof(GetRecipeStepById), new { id = recipeStep.StepId }, recipeStep);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRecipeStep(int id, [FromBody] RecipeStep recipeStep)
        {
            if (id != recipeStep.StepId)
            {
                return BadRequest("Step ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _recipeStepService.UpdateRecipeStep(recipeStep);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRecipeStep(int id)
        {
            var existingRecipeStep = _recipeStepService.GetRecipeStepById(id);
            if (existingRecipeStep == null)
            {
                return NotFound();
            }

            _recipeStepService.DeleteRecipeStep(id);
            return NoContent();
        }
    }
}
