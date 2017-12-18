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
    public class SettingsSQLMapper
    {
        private static List<Settings> usersList = new List<Settings>();

        public static string SQL_SINGLE_SELECT = "SELECT * FROM Settings WHERE iduser = @iduser";
        public static string SQL_INSERT = "INSERT INTO Settings VALUES (@iduser, @password, @firstName, @lastName)";
        public static string SQL_UPDATE = "UPDATE Settings SET login = @iduser, password=@password, firstName=@firstName, lastName=@lastName WHERE iduser=@iduser";

        public static List<Settings> settings { get => settings; set => settings = value; }


        public static int Insert(Settings set) {

            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, set);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }
        public static int Update(Settings set)
        {

            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, set);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }


        //Get settings of users


        // GET USER by ID
        // --------------

        public static Collection<Settings> getSettings(int id)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SINGLE_SELECT);
            PrepareCommand(command, id);
            SqlDataReader reader = db.Select(command);

            Collection<Settings> users = Read(reader);
            reader.Close();

            db.Close();

            return users;
        }

        private static Collection<Settings> Read(SqlDataReader reader)
        {
            Collection<Settings> sett = new Collection<Settings>();

            while (reader.Read())
            {
                int i = -1;
                Settings settings = new Settings();
                settings.id = reader.GetInt32(++i);
                settings.password = reader.GetString(++i);
                settings.firstName = reader.GetString(++i);
                settings.lastName = reader.GetString(++i);


                sett.Add(settings);
            }
            return sett;
        }
        //Select
        private static void PrepareCommand(SqlCommand command, int id)
        {
            command.Parameters.AddWithValue("@id", id);
        }
        //Insert a update
        private static void PrepareCommand(SqlCommand command, Settings set)
        {
            command.Parameters.AddWithValue("@id", set.id);
            command.Parameters.AddWithValue("@iduser", set.iduser);
            command.Parameters.AddWithValue("@firstName", set.firstName);
            command.Parameters.AddWithValue("@lastName", set.lastName);
            command.Parameters.AddWithValue("@password", set.password);
        }
    }
}