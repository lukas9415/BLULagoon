using BLULagoon.Models;
using Microsoft.Data.Sqlite;

namespace BLULagoon.Repository
{
    /// <summary>
    /// IngredientRepository is used for all actions that contain ingredients.
    /// </summary>
    public class IngredientRepository
    {
        /// <summary>
        /// Method to add a new ingredient to the database.
        /// <param name="ingredientName">ingredient name which will be added to the database</param>
        /// </summary>
        public void AddIngredient(string ingredientName)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "INSERT INTO Ingredient(ingredientName) VALUES "
            + "(@ingredientName)";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@ingredientName", ingredientName);


            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Method used to get all ingredients from the database.
        /// </summary>
        /// <returns>Returns a list of all ingredients</returns>
        public static List<Ingredient> GetAllIngredients()
        {
            SqliteConnection con1 = new SqliteConnection(@"Data Source=BLULagoon.db");

            con1.Open();
            string sql1 = "SELECT ingredientID, ingredientName FROM Ingredient";
            SqliteCommand command1 = new SqliteCommand(sql1, con1);
            SqliteDataReader reader1 = command1.ExecuteReader();
            List<Ingredient> allIngredients = new List<Ingredient>();
            while (reader1.Read())
            {
                Ingredient ingredient = new Ingredient();

                ingredient.ingredientID = reader1.GetInt32(reader1.GetOrdinal("ingredientID"));
                ingredient.ingredientName = reader1.GetString(reader1.GetOrdinal("ingredientName"));



                allIngredients.Add(ingredient);
            }
            reader1.Close();
            con1.Close();
            con1.Dispose();

            return allIngredients;
        }

        /// <summary>
        /// Method to delete an ingredient from the database.
        /// <param name="ingredientID">id of the ingredient which will be deleted</param>
        /// </summary>
        public void DeleteIngredient(int ingredientID)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "DELETE FROM Ingredient WHERE ingredientID = @ingredientID;";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@ingredientID", ingredientID);


            SqliteDataReader reader = command.ExecuteReader();

            reader.Close();
            con.Close();
            con.Dispose();

        }

        /// <summary>
        /// Method to update an ingredient name in the database.
        /// <param name="ingredientID">id of the ingredient which will be updated</param>
        /// <param name="ingredientName">name which will be specified for the selected id</param>
        /// </summary>
        public void UpdateIngredient(int ingredientID, string ingredientName)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "UPDATE Ingredient SET ingredientName=@ingredientName WHERE ingredientID = @ingredientID";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@ingredientID", ingredientID);
            command.Parameters.AddWithValue("@ingredientName", ingredientName);

            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
