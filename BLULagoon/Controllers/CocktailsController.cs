using BLULagoon.Models;
using BLULagoon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLULagoon.Controllers
{
    [Route("BLULagoon/[controller]")]
    [ApiController]
    public class CocktailsController : ControllerBase
    {
        CocktailRepository cocktailRepository = new CocktailRepository();

        [HttpGet]
        public List<Cocktail> Get()
        {
            return CocktailRepository.GetAllCocktails();
        }

        [HttpGet("byName/{cocktailName}")]
        public List<Cocktail> GetByName(string cocktailName)
        {
            return CocktailRepository.GetCocktailsByName(cocktailName);
        }

        [HttpGet("Users/{userID}")]
        public List<Cocktail> GetByUserID(int userID)
        {
            return CocktailRepository.GetAllCocktailsByUserID(userID);
        }

        [HttpGet("byIngredient/{ingredientName}")]
        public List<CocktailsByIngredients> GetCocktailsByIngredient(string ingredientName)
        {
            return CocktailRepository.GetCocktailsByIngredient(ingredientName);
        }

        [HttpPost]
        public PostCocktail PostNewCocktail([FromBody] PostCocktail cocktail)
        {
            cocktailRepository.AddNewCocktail(cocktail);

            return cocktail;
        }

        [HttpPost("Ingredient")]
        public AddCocktailIngredient PostNewIngredientToCocktail([FromBody] AddCocktailIngredient addCocktailIngredient)
        {
            cocktailRepository.AddIngredientToCocktail(addCocktailIngredient);

            return addCocktailIngredient;
        }

        [HttpGet("getSums")]
        public List<CocktailSum> GetCocktailSums()
        {
            return CocktailRepository.GetCocktailSums();
        }

        [HttpGet("getSums/{cocktailName}")]
        public List<CocktailSum> GetCocktailSumsByName(string cocktailName)
        {
            return CocktailRepository.GetCocktailSumsByName(cocktailName);
        }
    }
}
