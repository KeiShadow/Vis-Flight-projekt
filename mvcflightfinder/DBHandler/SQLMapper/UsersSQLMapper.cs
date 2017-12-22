using DBHandler.DataMapper;
using Mapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBHandler.SQLMapper
{
    public class UsersSQLMapper
    {
        private static List<Users> usersList = new List<Users>();

        public static string SQL_SINGLE_SELECT = "SELECT * FROM Users WHERE id = @id";
        public static string SQL_INSERT = "INSERT INTO Users VALUES (@Nick, @Email, @Password, @Firstname,@Lastname)";
        public static string SQL_SELECT = "SELECT * FROM Users";
        public static string SQL_UPDATE = "UPDATE Users SET Nick = @Nick, Email=@Email, Password=@Password WHERE id=@id";
        public static string SQL_SELECT_LOGIN = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";

        public static List<Users> Users { get => usersList; set => usersList = value; }

        // INSERT USER
        // -----------

        public static int Insert(Users user)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, user);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        // UPDATE USER
        // -----------

        public static int Update(Users user)
        {
            Database db;

            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, user);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        // GET ALL USERS
        // -------------

        public static Collection<Users> GetUsers()
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);

            SqlDataReader reader = db.Select(command);

            Collection<Users> users = Read(reader);
            reader.Close();

            db.Close();

            return users;
        }



        // GET USER by ID
        // --------------

        public static Collection<Users> GetUser(int id)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SINGLE_SELECT);
            PrepareCommand(command, id);
            SqlDataReader reader = db.Select(command);

            Collection<Users> users = Read(reader);
            reader.Close();

            db.Close();

            return users;
        }

        // Login where
        // --------------

        public static Collection<Users> Where(string email, string password)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT_LOGIN);
            PrepareCommand(command, email, password);
            SqlDataReader reader = command.ExecuteReader();

            Collection<Users> users = Read(reader);
            reader.Close();

            db.Close();

            return users;
        }

        // PREPARE COMMAND
        // ---------------

        private static void PrepareCommand(SqlCommand command, Users User)
        {
            command.Parameters.AddWithValue("@id", User.Id);
            command.Parameters.AddWithValue("@Nick", User.Nick);
            command.Parameters.AddWithValue("@email", User.Email);
            command.Parameters.AddWithValue("@password", User.Password);
            command.Parameters.AddWithValue("@Firstname", User.Firstname);
            command.Parameters.AddWithValue("@Lastname", User.Lastname);
        }

        private static void PrepareCommand(SqlCommand command, string email, string password)
        {
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
        }

        private static void PrepareCommand(SqlCommand command, int id)
        {
            command.Parameters.AddWithValue("@id", id);
        }


        // READ
        // ----

        private static Collection<Users> Read(SqlDataReader reader)
        {
            Collection<Users> users = new Collection<Users>();

            while (reader.Read())
            {
                int i = -1;
                Users user = new Users();
                user.Id = reader.GetInt32(++i);
                user.Nick = reader.GetString(++i);
                user.Email = reader.GetString(++i);
                user.Password = reader.GetString(++i);
                user.Firstname = reader.GetString(++i);
                user.Lastname = reader.GetString(++i);
                users.Add(user);
            }
            return users;
        }
    }
}