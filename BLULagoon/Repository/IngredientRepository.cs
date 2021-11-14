using BLULagoon.Models;
using Microsoft.Data.Sqlite;

namespace BLULagoon.Repository
{
    public class IngredientRepository
    {
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
