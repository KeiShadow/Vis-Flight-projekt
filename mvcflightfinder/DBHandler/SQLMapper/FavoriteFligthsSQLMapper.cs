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
    public class FavoriteFligthsSQLMapper
    {
        public static string SQL_SINGLE_SELECT = "SELECT * FROM FavoriteFligths WHERE IdUser = @IdUser";
        public static string SQL_INSERT = "INSERT INTO FavoriteFligths VALUES (@IdUser,@flyFrom, @flyTo, @DateFrom, @Price)";

        public static List<FavoriteFligths> favFlight { get => favFlight; set => favFlight = value; }

        public static int Insert(FavoriteFligths fav)
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

        public static Collection<FavoriteFligths> getFavFlights(int id)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SINGLE_SELECT);
            PrepareCommand(command, id);
            SqlDataReader reader = db.Select(command);

            Collection<FavoriteFligths> fav = Read(reader);
            reader.Close();

            db.Close();

            return fav;
        }

        private static Collection<FavoriteFligths> Read(SqlDataReader reader)
        {
            Collection<FavoriteFligths> bookFli = new Collection<FavoriteFligths>();

            while (reader.Read())
            {
                int i = -1;
                FavoriteFligths fav = new FavoriteFligths();
                fav.Idf= reader.GetInt32(++i);
                fav.IdUser = reader.GetInt32(++i);
                fav.FlyFrom = reader.GetString(++i);
                fav.FlyTo = reader.GetString(++i);
                fav.Datefrom = reader.GetString(++i);
                fav.Price = reader.GetInt32(++i);
                bookFli.Add(fav);
            }
            return bookFli;
        }

        private static void PrepareCommand(SqlCommand command, int id)
        {
            command.Parameters.AddWithValue("@IdUser", id);
        }

        private static void PrepareCommand(SqlCommand command, FavoriteFligths fav)
        {
            command.Parameters.AddWithValue("@Idf", fav.Idf);
            command.Parameters.AddWithValue("@IdUser", fav.IdUser);
            command.Parameters.AddWithValue("@flyFrom", fav.FlyFrom);
            command.Parameters.AddWithValue("@flyTo", fav.FlyTo);
            command.Parameters.AddWithValue("@DateFrom", fav.Datefrom);
            command.Parameters.AddWithValue("@Price", fav.Price);
           
        }
    }
}