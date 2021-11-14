using BLULagoon.Models;
using BLULagoon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLULagoon.Controllers
{
    [Route("BLULagoon/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        IngredientRepository ingredientRepository = new IngredientRepository();

        [HttpGet]
        public List<Ingredient> Get()
        {
            return IngredientRepository.GetAllIngredients();
        }

        [HttpPost]
        public List<Ingredient> PostNewIngredient(string ingredientName)
        {
            ingredientRepository.AddIngredient(ingredientName);

            return Get();
        }

        [HttpDelete("{ingredientID}")]
        public List<Ingredient> Delete(int ingredientID)
        {
            ingredientRepository.DeleteIngredient(ingredientID);

            return Get();
        }

        [HttpPut]
        public string Put(int ingredientID, string ingredientName)
        {
            ingredientRepository.UpdateIngredient(ingredientID, ingredientName);

            return "Updated ingredient ID: " + ingredientID + " with new name: " + ingredientName;

        }
    }
}
