using BLULagoon.Models;
using Microsoft.Data.Sqlite;

namespace BLULagoon.Repository
{
    /// <summary>
    /// CocktailRepository is used for all actions that contain cocktails.
    /// </summary>
    public class CocktailRepository
    {
        /// <summary>
        /// Method used to get all cocktails from the database.
        /// </summary>
        /// <returns>Returns a list of all cocktails</returns>
        public static List<Cocktail> GetAllCocktails()
        {
            //----- Visi ingredientai
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");

            con.Open();
            string sql = "SELECT Cocktail.cocktailID, Ingredient.ingredientName, CocktailIngredients.ingredientCount, Measure_Unit.unitShort " +
                "FROM CocktailIngredients " +
                "INNER JOIN Cocktail ON Cocktail.CocktailID = CocktailIngredients.CocktailID " +
                "INNER JOIN Ingredient ON Ingredient.IngredientID = CocktailIngredients.IngredientID " +
                "INNER JOIN Measure_Unit ON Measure_Unit.unitID = CocktailIngredients.ingredientUnit";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<CocktailIngredient> allIngredients = new List<CocktailIngredient>();
            while (reader.Read())
            {
                CocktailIngredient ingredient = new CocktailIngredient();

                ingredient.cocktailID = reader.GetInt32(reader.GetOrdinal("cocktailID"));
                ingredient.ingredientName = reader.GetString(reader.GetOrdinal("ingredientName"));
                ingredient.ingredientCount = reader.GetDouble(reader.GetOrdinal("ingredientCount"));
                ingredient.ingredientUnit = reader.GetString(reader.GetOrdinal("unitShort"));


                allIngredients.Add(ingredient);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            //--------------Visi kokteiliai------------------------------------------------------------------
            SqliteConnection con1 = new SqliteConnection(@"Data Source=BLULagoon.db");

            con1.Open();
            string sql1 = "SELECT cocktailID, cocktailName, description, Type.TypeName, Glass.GlassType, Taste.TasteName, Method.MethodName, IBA, instructions, userID FROM Cocktail " +
                "INNER JOIN Type ON Type.TypeID = Cocktail.type " +
                "INNER JOIN Glass ON Glass.GlassID = Cocktail.glassID " +
                "INNER JOIN Taste ON Taste.TasteID = Cocktail.taste " +
                "INNER JOIN Method ON Method.MethodID = Cocktail.method";
            SqliteCommand command1 = new SqliteCommand(sql1, con1);
            SqliteDataReader reader1 = command1.ExecuteReader();
            List<Cocktail> allCocktails = new List<Cocktail>();
            while (reader1.Read())
            {
                Cocktail cocktail = new Cocktail();

                cocktail.cocktailID = reader1.GetInt32(reader1.GetOrdinal("cocktailID"));
                cocktail.cocktailName = reader1.GetString(reader1.GetOrdinal("cocktailName"));
                cocktail.description = reader1.GetString(reader1.GetOrdinal("description"));
                cocktail.type = reader1.GetString(reader1.GetOrdinal("TypeName"));
                cocktail.glass = reader1.GetString(reader1.GetOrdinal("GlassType"));
                cocktail.taste = reader1.GetString(reader1.GetOrdinal("TasteName"));
                cocktail.method = reader1.GetString(reader1.GetOrdinal("MethodName"));
                bool test = reader1.GetBoolean(reader1.GetOrdinal("IBA"));

                if (reader1.GetString(reader1.GetOrdinal("IBA")) == "TRUE")
                {
                    cocktail.IBA = "+";
                }
                else cocktail.IBA = "-";

                cocktail.instructions = reader1.GetString(reader1.GetOrdinal("instructions"));

                foreach (CocktailIngredient ingredient in allIngredients)
                {
                    if (cocktail.cocktailID == ingredient.cocktailID)
                    {
                        CocktailIngredientNoID ingr = new CocktailIngredientNoID();
                        ingr.ingredientName = ingredient.ingredientName;
                        ingr.ingredientCount = ingredient.ingredientCount;
                        ingr.ingredientUnit = ingredient.ingredientUnit;

                        cocktail.CocktailIngredients.Add(ingr);
                    }
                }


                allCocktails.Add(cocktail);
            }
            reader1.Close();
            con1.Close();
            con1.Dispose();

            return allCocktails;
        }

        /// <summary>
        /// Method to get all cocktails from the database filtering by userid.
        /// </summary>
        /// <param name="userID">userid of whose cocktails you would want to see</param>
        /// <returns>Returns list of all cocktails by the specified userid</returns>
        public static List<Cocktail> GetAllCocktailsByUserID(int userID)
        {
            //----- Visi ingredientai
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");

            con.Open();
            string sql = "SELECT Cocktail.cocktailID, Ingredient.ingredientName, CocktailIngredients.ingredientCount, Measure_Unit.unitShort " +
                "FROM CocktailIngredients " +
                "INNER JOIN Cocktail ON Cocktail.CocktailID = CocktailIngredients.CocktailID " +
                "INNER JOIN Ingredient ON Ingredient.IngredientID = CocktailIngredients.IngredientID " +
                "INNER JOIN Measure_Unit ON Measure_Unit.unitID = CocktailIngredients.ingredientUnit";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<CocktailIngredient> allIngredients = new List<CocktailIngredient>();
            while (reader.Read())
            {
                CocktailIngredient ingredient = new CocktailIngredient();

                ingredient.cocktailID = reader.GetInt32(reader.GetOrdinal("cocktailID"));
                ingredient.ingredientName = reader.GetString(reader.GetOrdinal("ingredientName"));
                ingredient.ingredientCount = reader.GetDouble(reader.GetOrdinal("ingredientCount"));
                ingredient.ingredientUnit = reader.GetString(reader.GetOrdinal("unitShort"));


                allIngredients.Add(ingredient);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            //--------------Visi kokteiliai------------------------------------------------------------------
            SqliteConnection con1 = new SqliteConnection(@"Data Source=BLULagoon.db");

            con1.Open();
            string sql1 = "SELECT cocktailID, cocktailName, description, Type.TypeName, Glass.GlassType, Taste.TasteName, Method.MethodName, IBA, instructions, userID FROM Cocktail " +
                "INNER JOIN Type ON Type.TypeID = Cocktail.type " +
                "INNER JOIN Glass ON Glass.GlassID = Cocktail.glassID " +
                "INNER JOIN Taste ON Taste.TasteID = Cocktail.taste " +
                "INNER JOIN Method ON Method.MethodID = Cocktail.method " +
                "WHERE userID = "+userID;
            SqliteCommand command1 = new SqliteCommand(sql1, con1);
            SqliteDataReader reader1 = command1.ExecuteReader();
            List<Cocktail> allCocktails = new List<Cocktail>();
            while (reader1.Read())
            {
                Cocktail cocktail = new Cocktail();

                cocktail.cocktailID = reader1.GetInt32(reader1.GetOrdinal("cocktailID"));
                cocktail.cocktailName = reader1.GetString(reader1.GetOrdinal("cocktailName"));
                cocktail.description = reader1.GetString(reader1.GetOrdinal("description"));
                cocktail.type = reader1.GetString(reader1.GetOrdinal("TypeName"));
                cocktail.glass = reader1.GetString(reader1.GetOrdinal("GlassType"));
                cocktail.taste = reader1.GetString(reader1.GetOrdinal("TasteName"));
                cocktail.method = reader1.GetString(reader1.GetOrdinal("MethodName"));
                bool test = reader1.GetBoolean(reader1.GetOrdinal("IBA"));

                if (reader1.GetString(reader1.GetOrdinal("IBA")) == "TRUE")
                {
                    cocktail.IBA = "+";
                }
                else cocktail.IBA = "-";

                cocktail.instructions = reader1.GetString(reader1.GetOrdinal("instructions"));

                foreach (CocktailIngredient ingredient in allIngredients)
                {
                    if (cocktail.cocktailID == ingredient.cocktailID)
                    {
                        CocktailIngredientNoID ingr = new CocktailIngredientNoID();
                        ingr.ingredientName = ingredient.ingredientName;
                        ingr.ingredientCount = ingredient.ingredientCount;
                        ingr.ingredientUnit = ingredient.ingredientUnit;

                        cocktail.CocktailIngredients.Add(ingr);
                    }
                }


                allCocktails.Add(cocktail);
            }
            reader1.Close();
            con1.Close();
            con1.Dispose();

            return allCocktails;
        }


        /// <summary>
        /// Method to get all cocktails from the database filtering by cocktail name.
        /// </summary>
        /// <param name="cocktailName">name of the cocktail you would want to see</param>
        /// <returns>Returns list of all cocktails containing the specified name</returns>
        public static List<Cocktail> GetCocktailsByName(string cocktailName)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");

            con.Open();
            string sql = "SELECT Cocktail.cocktailID, Ingredient.ingredientName, CocktailIngredients.ingredientCount, Measure_Unit.unitShort " +
                "FROM CocktailIngredients " +
                "INNER JOIN Cocktail ON Cocktail.CocktailID = CocktailIngredients.CocktailID " +
                "INNER JOIN Ingredient ON Ingredient.IngredientID = CocktailIngredients.IngredientID " +
                "INNER JOIN Measure_Unit ON Measure_Unit.unitID = CocktailIngredients.ingredientUnit";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<CocktailIngredient> allIngredients = new List<CocktailIngredient>();
            while (reader.Read())
            {
                CocktailIngredient ingredient = new CocktailIngredient();

                ingredient.cocktailID = reader.GetInt32(reader.GetOrdinal("cocktailID"));
                ingredient.ingredientName = reader.GetString(reader.GetOrdinal("ingredientName"));
                ingredient.ingredientCount = reader.GetDouble(reader.GetOrdinal("ingredientCount"));
                ingredient.ingredientUnit = reader.GetString(reader.GetOrdinal("unitShort"));


                allIngredients.Add(ingredient);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            //---------------------------------------------------------------------------------------------
            SqliteConnection con1 = new SqliteConnection(@"Data Source=BLULagoon.db");

            con1.Open();
            string sql1 = "SELECT cocktailID, cocktailName, description, Type.TypeName, Glass.GlassType, Taste.TasteName, Method.MethodName, IBA, instructions, userID FROM Cocktail " +
                "INNER JOIN Type ON Type.TypeID = Cocktail.type " +
                "INNER JOIN Glass ON Glass.GlassID = Cocktail.glassID " +
                "INNER JOIN Taste ON Taste.TasteID = Cocktail.taste " +
                "INNER JOIN Method ON Method.MethodID = Cocktail.method " +
                "WHERE cocktailName LIKE '%" + cocktailName + "%'";
            SqliteCommand command1 = new SqliteCommand(sql1, con1);
            SqliteDataReader reader1 = command1.ExecuteReader();
            List<Cocktail> allCocktails = new List<Cocktail>();
            while (reader1.Read())
            {
                Cocktail cocktail = new Cocktail();

                cocktail.cocktailID = reader1.GetInt32(reader1.GetOrdinal("cocktailID"));
                cocktail.cocktailName = reader1.GetString(reader1.GetOrdinal("cocktailName"));
                cocktail.description = reader1.GetString(reader1.GetOrdinal("description"));
                cocktail.type = reader1.GetString(reader1.GetOrdinal("TypeName"));
                cocktail.glass = reader1.GetString(reader1.GetOrdinal("GlassType"));
                cocktail.taste = reader1.GetString(reader1.GetOrdinal("TasteName"));
                cocktail.method = reader1.GetString(reader1.GetOrdinal("MethodName"));
                bool test = reader1.GetBoolean(reader1.GetOrdinal("IBA"));

                if (reader1.GetString(reader1.GetOrdinal("IBA")) == "TRUE")
                {
                    cocktail.IBA = "+";
                }
                else cocktail.IBA = "-";

                cocktail.instructions = reader1.GetString(reader1.GetOrdinal("instructions"));

                foreach (CocktailIngredient ingredient in allIngredients)
                {
                    if (cocktail.cocktailID == ingredient.cocktailID)
                    {
                        CocktailIngredientNoID ingr = new CocktailIngredientNoID();
                        ingr.ingredientName = ingredient.ingredientName;
                        ingr.ingredientCount = ingredient.ingredientCount;
                        ingr.ingredientUnit = ingredient.ingredientUnit;

                        cocktail.CocktailIngredients.Add(ingr);
                    }
                }


                allCocktails.Add(cocktail);
            }
            reader1.Close();
            con1.Close();
            con1.Dispose();

            return allCocktails;
        }

        /// <summary>
        /// Method to get all cocktails from the database containing selected ingredient.
        /// </summary>
        /// <param name="ingredientName">name of the ingredient in the cocktails you would want to see</param>
        /// <returns>Returns list of all cocktails with the specified ingredient</returns>
        public static List<CocktailsByIngredients> GetCocktailsByIngredient(string ingredientName)
        {
            SqliteConnection con1 = new SqliteConnection(@"Data Source=BLULagoon.db");

            con1.Open();
            string sql1 = "SELECT Cocktail.cocktailName, CocktailIngredients.ingredientCount, Measure_Unit.unitShort " +
                "FROM CocktailIngredients " +
                "INNER JOIN Cocktail ON Cocktail.CocktailID = CocktailIngredients.CocktailID " +
                "INNER JOIN Ingredient ON Ingredient.IngredientID = CocktailIngredients.IngredientID " +
                "INNER JOIN Measure_Unit ON Measure_Unit.unitID = CocktailIngredients.ingredientUnit " +
                "WHERE ingredientName LIKE '%" + ingredientName + "%'";
            SqliteCommand command1 = new SqliteCommand(sql1, con1);
            SqliteDataReader reader1 = command1.ExecuteReader();
            List<CocktailsByIngredients> cocktailsByIngredients = new List<CocktailsByIngredients>();
            while (reader1.Read())
            {
                CocktailsByIngredients co = new CocktailsByIngredients();

                co.cocktailName = reader1.GetString(reader1.GetOrdinal("cocktailName"));
                co.ingredientCount = reader1.GetDouble(reader1.GetOrdinal("ingredientCount"));
                co.unitShort = reader1.GetString(reader1.GetOrdinal("unitShort"));


                cocktailsByIngredients.Add(co);
            }
            reader1.Close();
            con1.Close();
            con1.Dispose();

            return cocktailsByIngredients;
        }

        /// <summary>
        /// Method to get all cocktail ingredients sums from the database.
        /// </summary>
        /// <returns>Returns list of all cocktail ingredient sums</returns>
        public static List<CocktailSum> GetCocktailSums()
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");

            con.Open();
            string sql = "SELECT Cocktail.cocktailID, Ingredient.ingredientName, CocktailIngredients.ingredientCount, Measure_Unit.unitShort " +
                "FROM CocktailIngredients " +
                "INNER JOIN Cocktail ON Cocktail.CocktailID = CocktailIngredients.CocktailID " +
                "INNER JOIN Ingredient ON Ingredient.IngredientID = CocktailIngredients.IngredientID " +
                "INNER JOIN Measure_Unit ON Measure_Unit.unitID = CocktailIngredients.ingredientUnit";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<CocktailIngredient> allIngredients = new List<CocktailIngredient>();
            while (reader.Read())
            {
                CocktailIngredient ingredient = new CocktailIngredient();

                ingredient.cocktailID = reader.GetInt32(reader.GetOrdinal("cocktailID"));
                ingredient.ingredientName = reader.GetString(reader.GetOrdinal("ingredientName"));
                ingredient.ingredientCount = reader.GetDouble(reader.GetOrdinal("ingredientCount"));
                ingredient.ingredientUnit = reader.GetString(reader.GetOrdinal("unitShort"));


                allIngredients.Add(ingredient);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            //---------------------------------------------------------------------------------------------
            SqliteConnection con1 = new SqliteConnection(@"Data Source=BLULagoon.db");

            con1.Open();
            string sql1 = "SELECT cocktailID, cocktailName FROM Cocktail ";

            SqliteCommand command1 = new SqliteCommand(sql1, con1);
            SqliteDataReader reader1 = command1.ExecuteReader();
            List<CocktailSum> cocktailSums = new List<CocktailSum>();
            while (reader1.Read())
            {
                CocktailSum cocktailS = new CocktailSum();

                cocktailS.cocktailID = reader1.GetInt32(reader1.GetOrdinal("cocktailID"));
                cocktailS.cocktailName = reader1.GetString(reader1.GetOrdinal("cocktailName"));

                foreach (CocktailIngredient ingredient in allIngredients)
                {
                    if (cocktailS.cocktailID == ingredient.cocktailID)
                    {
                        cocktailS.cocktailSum += ingredient.ingredientCount;
                        if(ingredient.ingredientUnit == "ml" || ingredient.ingredientUnit == "oz")
                        {
                            cocktailS.unit = ingredient.ingredientUnit;
                        }
                    }
                }


                cocktailSums.Add(cocktailS);
            }
            reader1.Close();
            con1.Close();
            con1.Dispose();

            return cocktailSums;
        }

        /// <summary>
        /// Method to get all cocktail ingredients sums from the database filtered by cocktail name.
        /// <param name="cocktailName">name of the cocktail which ingredients you want to see</param>
        /// </summary>
        /// <returns>Returns list of all cocktail ingredient sums of the specified cocktail</returns>
        public static List<CocktailSum> GetCocktailSumsByName(string cocktailName)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");

            con.Open();
            string sql = "SELECT Cocktail.cocktailID, Ingredient.ingredientName, CocktailIngredients.ingredientCount, Measure_Unit.unitShort " +
                "FROM CocktailIngredients " +
                "INNER JOIN Cocktail ON Cocktail.CocktailID = CocktailIngredients.CocktailID " +
                "INNER JOIN Ingredient ON Ingredient.IngredientID = CocktailIngredients.IngredientID " +
                "INNER JOIN Measure_Unit ON Measure_Unit.unitID = CocktailIngredients.ingredientUnit ";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<CocktailIngredient> allIngredients = new List<CocktailIngredient>();
            while (reader.Read())
            {
                CocktailIngredient ingredient = new CocktailIngredient();

                ingredient.cocktailID = reader.GetInt32(reader.GetOrdinal("cocktailID"));
                ingredient.ingredientName = reader.GetString(reader.GetOrdinal("ingredientName"));
                ingredient.ingredientCount = reader.GetDouble(reader.GetOrdinal("ingredientCount"));
                ingredient.ingredientUnit = reader.GetString(reader.GetOrdinal("unitShort"));


                allIngredients.Add(ingredient);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            //---------------------------------------------------------------------------------------------
            SqliteConnection con1 = new SqliteConnection(@"Data Source=BLULagoon.db");

            con1.Open();
            string sql1 = "SELECT cocktailID, cocktailName FROM Cocktail " +
                          "WHERE cocktailName LIKE '%" + cocktailName + "%'"; 

            SqliteCommand command1 = new SqliteCommand(sql1, con1);
            SqliteDataReader reader1 = command1.ExecuteReader();
            List<CocktailSum> cocktailSums = new List<CocktailSum>();
            while (reader1.Read())
            {
                CocktailSum cocktailS = new CocktailSum();

                cocktailS.cocktailID = reader1.GetInt32(reader1.GetOrdinal("cocktailID"));
                cocktailS.cocktailName = reader1.GetString(reader1.GetOrdinal("cocktailName"));

                foreach (CocktailIngredient ingredient in allIngredients)
                {
                    if (cocktailS.cocktailID == ingredient.cocktailID)
                    {
                        cocktailS.cocktailSum += ingredient.ingredientCount;
                        if (ingredient.ingredientUnit == "ml" || ingredient.ingredientUnit == "oz")
                        {
                            cocktailS.unit = ingredient.ingredientUnit;
                        }
                    }
                }


                cocktailSums.Add(cocktailS);
            }
            reader1.Close();
            con1.Close();
            con1.Dispose();

            return cocktailSums;
        }

        /// <summary>
        /// Method to add a new cocktail to the database.
        /// <param name="cocktail">cocktail object with all the required information for adding to the database</param>
        /// </summary>
        public void AddNewCocktail(PostCocktail cocktail)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "INSERT INTO Cocktail(cocktailName, description, type, glassID, taste, method, IBA, instructions, userID) VALUES "
            + "(@cocktailName, @description, @type, @glassID, @taste, @method, @IBA, @instructions, @userID)";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@cocktailName", cocktail.cocktailName);
            command.Parameters.AddWithValue("@description", cocktail.description);
            command.Parameters.AddWithValue("@type", cocktail.type);
            command.Parameters.AddWithValue("@glassID", cocktail.glass);
            command.Parameters.AddWithValue("@taste", cocktail.taste);
            command.Parameters.AddWithValue("@method", cocktail.method);

            command.Parameters.AddWithValue("@IBA", cocktail.IBA);
            command.Parameters.AddWithValue("@instructions", cocktail.instructions);
            command.Parameters.AddWithValue("@userID", cocktail.userID);

            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Method to add a new ingredient to the cocktail.
        /// <param name="ingredient">ingredient object with all the required information for adding to the cocktail</param>
        /// </summary>
        public void AddIngredientToCocktail(AddCocktailIngredient ingredient)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "INSERT INTO CocktailIngredients(CocktailID, IngredientID, ingredientCount, ingredientUnit) VALUES "
            + "(@CocktailID, @IngredientID, @ingredientCount, @ingredientUnit)";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@CocktailID", ingredient.cocktailID);
            command.Parameters.AddWithValue("@IngredientID", ingredient.ingredientID);
            command.Parameters.AddWithValue("@ingredientCount", ingredient.ingredientCount);
            command.Parameters.AddWithValue("@ingredientUnit", ingredient.ingredientUnit);

            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Method to delete a cocktail from the database.
        /// <param name="cocktailID">id of the cocktail which will be deleted</param>
        /// </summary>
        public void DeleteCocktail(int cocktailID)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "DELETE FROM CocktailIngredients WHERE CocktailID = @CocktailID;" +
                "DELETE FROM Cocktail WHERE cocktailID = @cocktailID";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@CocktailID", cocktailID);
            command.Parameters.AddWithValue("@cocktailID", cocktailID);

            SqliteDataReader reader = command.ExecuteReader();

            reader.Close();
            con.Close();
            con.Dispose();

        }


    }
}
