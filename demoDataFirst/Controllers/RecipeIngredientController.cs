using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIngredientService _service;

        public RecipeIngredientController(IRecipeIngredientService service)
        {
            _service = service;
        }

        // GET: api/RecipeIngredient
        [HttpGet]
        public ActionResult<IEnumerable<RecipeIngredient>> GetRecipeIngredients()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        // GET: api/RecipeIngredient/5
        [HttpGet("{id}")]
        public ActionResult<RecipeIngredient> GetRecipeIngredient(int id)
        {
            var recipeIngredient = _service.GetById(id);

            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return recipeIngredient;
        }

        // POST: api/RecipeIngredient
        [HttpPost]
        public ActionResult<RecipeIngredient> PostRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _service.Add(recipeIngredient);
            return CreatedAtAction(nameof(GetRecipeIngredient), new { id = recipeIngredient.IngredientId }, recipeIngredient);
        }

        // PUT: api/RecipeIngredient/5
        [HttpPut("{id}")]
        public IActionResult PutRecipeIngredient(int id, RecipeIngredient recipeIngredient)
        {
            if (id != recipeIngredient.IngredientId)
            {
                return BadRequest();
            }

            _service.Update(recipeIngredient);

            return NoContent();
        }

        // DELETE: api/RecipeIngredient/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipeIngredient(int id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
