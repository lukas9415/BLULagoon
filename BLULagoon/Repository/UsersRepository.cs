using BLULagoon.Models;
using Microsoft.Data.Sqlite;

namespace BLULagoon.Repository
{
    public class UsersRepository
    {
        public static List<User> GetAllUsers()
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");

            con.Open();
            string sql = "SELECT * FROM User";
            SqliteCommand command = new SqliteCommand(sql, con);
            SqliteDataReader reader = command.ExecuteReader();
            List<User> allUsers = new List<User>();
            while (reader.Read())
            {
                User user = new User();
                user.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                user.Name = reader.GetString(reader.GetOrdinal("Name"));
                user.Surname = reader.GetString(reader.GetOrdinal("Surname"));


                allUsers.Add(user);
            }
            reader.Close();
            con.Close();
            con.Dispose();

            return allUsers;
        }

        public void AddNewUser(User newUser)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "INSERT INTO User(Name, Surname) VALUES "
            + "(@Name, @Surname)";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@Name", newUser.Name);
            command.Parameters.AddWithValue("@Surname", newUser.Surname);


            command.Prepare();
            command.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteUser(int UserID)
        {
            SqliteConnection con = new SqliteConnection(@"Data Source=BLULagoon.db");
            con.Open();
            string sql = "DELETE FROM User WHERE UserID = @UserID";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@UserID", UserID);

            SqliteDataReader reader = command.ExecuteReader();

            reader.Close();
            con.Close();
            con.Dispose();
        }
    }
}
