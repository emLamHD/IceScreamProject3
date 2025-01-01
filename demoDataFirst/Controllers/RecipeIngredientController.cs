using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService)
        {
            _recipeIngredientService = recipeIngredientService;
        }

        [HttpGet]
        public IActionResult GetAllIngredients()
        {
            var ingredients = _recipeIngredientService.GetAllIngredients();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public IActionResult GetIngredientById(int id)
        {
            var ingredient = _recipeIngredientService.GetIngredientById(id);
            if (ingredient == null) return NotFound();
            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient(RecipeIngredient ingredient)
        {
            try
            {
                await _recipeIngredientService.CreateIngredientAsync(ingredient);
                return CreatedAtAction(nameof(GetIngredientById), new { id = ingredient.IngredientId }, ingredient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, RecipeIngredient ingredient)
        {
            if (id != ingredient.IngredientId) return BadRequest("Ingredient ID không khớp.");

            await _recipeIngredientService.UpdateIngredientAsync(ingredient);
            return Ok("Cập nhật thành công.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await _recipeIngredientService.DeleteIngredientAsync(id);
            return Ok("Xóa thành công.");
        }
    }
}
