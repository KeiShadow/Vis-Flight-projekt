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
    public class FavFlightsSQLMapper
    {
        public static string SQL_SINGLE_SELECT = "SELECT * FROM Favorite_flights WHERE iduser = @iduser";
        public static string SQL_INSERT = "INSERT INTO Favorite_flights VALUES (@iduser,@flightFrom, @flightTo, @dateFrom, @price)";

        public static List<Favorite_fligths> favFlight { get => favFlight; set => favFlight = value; }

        public static int Insert(Favorite_fligths fav)
        {

            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, fav);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static Collection<Favorite_fligths> getFavFlights(int id)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SINGLE_SELECT);
            PrepareCommand(command, id);
            SqlDataReader reader = db.Select(command);

            Collection<Favorite_fligths> fav = Read(reader);
            reader.Close();

            db.Close();

            return fav;
        }

        private static Collection<Favorite_fligths> Read(SqlDataReader reader)
        {
            Collection<Favorite_fligths> favCol = new Collection<Favorite_fligths>();

            while (reader.Read())
            {
                int i = -1;
                Favorite_fligths fav = new Favorite_fligths();
                fav.id = reader.GetInt32(++i);
                fav.iduser = reader.GetInt32(++i);
                fav.flightFrom = reader.GetString(++i);
                fav.flightTo = reader.GetString(++i);
                fav.dateFrom = reader.GetString(++i);
                fav.price = reader.GetString(++i);


                favCol.Add(fav);
            }
            return favCol;
        }

        private static void PrepareCommand(SqlCommand command, int id)
        {
            command.Parameters.AddWithValue("@iduser", id);
        }

        private static void PrepareCommand(SqlCommand command, Favorite_fligths fav)
        {
            command.Parameters.AddWithValue("@id", fav.id);
            command.Parameters.AddWithValue("@iduser", fav.iduser);
            command.Parameters.AddWithValue("@flightFrom", fav.flightFrom);
            command.Parameters.AddWithValue("@flightTo", fav.flightTo);
            command.Parameters.AddWithValue("@dateFrom", fav.dateFrom);
            command.Parameters.AddWithValue("@price", fav.price);
        }
    }
}