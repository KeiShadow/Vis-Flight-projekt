using Mapper.DB;
using MvcFlightFinder.DataMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcFlightFinder.SQLMapper
{
    public class UsersSQLMapper
    {
        private static List<Users> usersList = new List<Users>();

        public static string SQL_SINGLE_SELECT = "SELECT * FROM Users WHERE id = @id";
        public static string SQL_INSERT = "INSERT INTO Users VALUES (@login, @email, @password, @permission)";
        public static string SQL_SELECT = "SELECT * FROM Users";
        public static string SQL_UPDATE = "UPDATE Users SET login = @login, email=@email, password=@password WHERE id=@id";
        public static string SQL_SELECT_LOGIN = "SELECT * FROM Users WHERE email = @email AND password = @password";

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

        // GET USER by ID
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
            command.Parameters.AddWithValue("@id", User.id);
            command.Parameters.AddWithValue("@login", User.login);
            command.Parameters.AddWithValue("@email", User.email);
            command.Parameters.AddWithValue("@password", User.password);
            command.Parameters.AddWithValue("@permission", User.permision);
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
                user.id = reader.GetInt32(++i);
                user.login = reader.GetString(++i);
                user.email = reader.GetString(++i);
                user.password = reader.GetString(++i);
                user.permision = reader.GetString(++i);
                users.Add(user);
            }
            return users;
        }
    }
}