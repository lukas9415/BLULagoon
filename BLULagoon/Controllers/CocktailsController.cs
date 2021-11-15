using BLULagoon.Models;
using BLULagoon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLULagoon.Controllers
{
    /// <summary>
    /// Controller for cocktail requests.
    /// </summary>
    [Route("BLULagoon/[controller]")]
    [ApiController]
    public class CocktailsController : ControllerBase
    {
        CocktailRepository cocktailRepository = new CocktailRepository();

        /// <summary>
        /// Request to get all cocktails from the database.
        /// 
        /// <c>GET: BLULagoon/Cocktails</c>
        /// </summary>
        /// <returns>Returns all existing cocktails</returns>
        [HttpGet]
        public List<Cocktail> Get()
        {
            return CocktailRepository.GetAllCocktails();
        }

        /// <summary>
        /// Request to get cocktails from the database by their name.
        /// 
        /// <c>GET: BLULagoon/Cocktails</c>
        /// <param name="cocktailName">Cocktail name which will be searched for</param>
        /// </summary>
        /// <returns>Returns all cocktails with selected name</returns>
        [HttpGet("byName/{cocktailName}")]
        public List<Cocktail> GetByName(string cocktailName)
        {
            return CocktailRepository.GetCocktailsByName(cocktailName);
        }

        /// <summary>
        /// Request to get cocktails from the database by userID
        /// 
        /// <c>GET: BLULagoon/Cocktails</c>
        /// <param name="userID">userID which comes from the request</param>
        /// </summary>
        /// <returns>Returns all cocktails from the selected userID</returns>
        [HttpGet("Users/{userID}")]
        public List<Cocktail> GetByUserID(int userID)
        {
            return CocktailRepository.GetAllCocktailsByUserID(userID);
        }


        /// <summary>
        /// Request to get cocktails from the database by their ingredient
        /// 
        /// <c>GET: BLULagoon/Cocktails</c>
        /// <param name="ingredientName">ingredientName which comes from the request</param>
        /// </summary>
        /// <returns>Returns all cocktails with the selected ingredient</returns>
        [HttpGet("byIngredient/{ingredientName}")]
        public List<CocktailsByIngredients> GetCocktailsByIngredient(string ingredientName)
        {
            return CocktailRepository.GetCocktailsByIngredient(ingredientName);
        }

        /// <summary>
        /// Request to add a new cocktail to the database
        /// 
        /// <c>POST: BLULagoon/Cocktails</c>
        /// <param name="cocktail">cocktail object with all the required information for adding</param>
        /// </summary>
        /// <returns>Returns the added cocktail object</returns>
        [HttpPost]
        public PostCocktail PostNewCocktail([FromBody] PostCocktail cocktail)
        {
            cocktailRepository.AddNewCocktail(cocktail);

            return cocktail;
        }

        /// <summary>
        /// Request to add a new ingredient to the cocktail
        /// 
        /// <c>POST: BLULagoon/Cocktails</c>
        /// <param name="addCocktailIngredient">cocktail ingredient object with all the required information for adding</param>
        /// </summary>
        /// <returns>Returns the added cocktail ingredient object</returns>
        [HttpPost("Ingredient")]
        public AddCocktailIngredient PostNewIngredientToCocktail([FromBody] AddCocktailIngredient addCocktailIngredient)
        {
            cocktailRepository.AddIngredientToCocktail(addCocktailIngredient);

            return addCocktailIngredient;
        }

        /// <summary>
        /// Request to get all cocktail ingredient sums
        /// 
        /// <c>GET: BLULagoon/Cocktails</c>
        /// </summary>
        /// <returns>Returns cocktail ingredient sums</returns>
        [HttpGet("getSums")]
        public List<CocktailSum> GetCocktailSums()
        {
            return CocktailRepository.GetCocktailSums();
        }

        /// <summary>
        /// Request to get cocktail ingredient sum by cocktail name
        /// 
        /// <c>GET: BLULagoon/Cocktails</c>
        /// <param name="cocktailName">cocktail name which comes from the request used for searching</param>
        /// </summary>
        /// <returns>Returns the selected cocktail ingredient sum</returns>
        [HttpGet("getSums/{cocktailName}")]
        public List<CocktailSum> GetCocktailSumsByName(string cocktailName)
        {
            return CocktailRepository.GetCocktailSumsByName(cocktailName);
        }

        /// <summary>
        /// Request to delete a cocktail from the database
        /// 
        /// <c>DELETE: BLULagoon/Cocktails</c>
        /// <param name="cocktailID">cocktailID which will be deleted</param>
        /// </summary>
        /// <returns>Returns all cocktails without the deleted one</returns>
        [HttpDelete("{cocktailID}")]
        public List<Cocktail> Delete(int cocktailID)
        {
            cocktailRepository.DeleteCocktail(cocktailID);

            return Get();
        }
    }
}
