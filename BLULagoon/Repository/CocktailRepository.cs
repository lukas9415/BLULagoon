using BLULagoon.Models;
using Microsoft.Data.Sqlite;

namespace BLULagoon.Repository
{
    public class CocktailRepository
    {
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


    }
}
