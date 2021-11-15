using BLULagoon.Models;
using BLULagoon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLULagoon.Controllers
{
    /// <summary>
    /// Controller for ingredient requests.
    /// </summary>
    [Route("BLULagoon/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        IngredientRepository ingredientRepository = new IngredientRepository();

        /// <summary>
        /// Request to get all ingredients from the database.
        /// 
        /// <c>GET: BLULagoon/Ingredients</c>
        /// </summary>
        /// <returns>Returns all existing ingredients</returns>
        [HttpGet]
        public List<Ingredient> Get()
        {
            return IngredientRepository.GetAllIngredients();
        }

        /// <summary>
        /// Request to add a new ingredient to the database.
        /// 
        /// <c>POST: BLULagoon/Ingredients</c>
        /// </summary>
        /// <param name="ingredientName">New ingredient name which comes from the request</param>
        /// <returns>Returns all existing ingredients with the new one</returns>
        [HttpPost]
        public List<Ingredient> PostNewIngredient(string ingredientName)
        {
            ingredientRepository.AddIngredient(ingredientName);

            return Get();
        }


        /// <summary>
        /// Request to delete an ingredient from the database.
        /// 
        /// <c>DELETE: BLULagoon/Ingredients/{ingredientID}</c>
        /// </summary>
        /// <param name="ingredientID">ingredientID which comes from the request</param>
        /// <returns>Returns all ingredients after deletion</returns>
        [HttpDelete("{ingredientID}")]
        public List<Ingredient> Delete(int ingredientID)
        {
            ingredientRepository.DeleteIngredient(ingredientID);

            return Get();
        }

        /// <summary>
        /// Request to update an ingredient from the database.
        /// 
        /// <c>PUT: BLULagoon/Ingredients</c>
        /// </summary>
        /// <param name="ingredientID">ingredientID which comes from the request</param>
        /// <param name="ingredientName">name which the ingredient will be updated to</param>
        /// <returns>Returns information about the updated ingredient</returns>
        [HttpPut]
        public string Put(int ingredientID, string ingredientName)
        {
            ingredientRepository.UpdateIngredient(ingredientID, ingredientName);

            return "Updated ingredient ID: " + ingredientID + " with new name: " + ingredientName;

        }
    }
}
