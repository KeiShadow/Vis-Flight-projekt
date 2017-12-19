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
    public class BookedFlightsSQLMapper
    {
        public static string SQL_SINGLE_SELECT = "SELECT * FROM BookedFlights WHERE Users_id = @Users_id";
        public static string SQL_INSERT = "INSERT INTO BookedFlights VALUES (@flyFrom, @flyTo, @DateFrom,@Peoples, @Price,@Users_id,@DateOfRes)";

        public static List<BookedFlights> favFlight { get => favFlight; set => favFlight = value; }

        public static int Insert(BookedFlights book)
        {

            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, book);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static Collection<BookedFlights> getFavFlights(int id)
        {
            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SINGLE_SELECT);
            PrepareCommand(command, id);
            SqlDataReader reader = db.Select(command);

            Collection<BookedFlights> book = Read(reader);
            reader.Close();

            db.Close();

            return book;
        }

        private static Collection<BookedFlights> Read(SqlDataReader reader)
        {
            Collection<BookedFlights> bookFli = new Collection<BookedFlights>();

            while (reader.Read())
            {
                int i = -1;
                BookedFlights book = new BookedFlights();
                book.Idb = reader.GetInt32(++i);
                book.FlyFrom = reader.GetString(++i);
                book.FlyTo = reader.GetString(++i);
                book.Datefrom = reader.GetDateTime(++i);
                book.Peoples = reader.GetInt32(++i);
                book.Price = reader.GetInt32(++i);
                book.Users_id = reader.GetInt32(++i);
                book.Dateofres = reader.GetDateTime(++i);


                bookFli.Add(book);
            }
            return bookFli;
        }

        private static void PrepareCommand(SqlCommand command, int id)
        {
            command.Parameters.AddWithValue("@Users_id", id);
        }

        private static void PrepareCommand(SqlCommand command, BookedFlights book)
        {
            command.Parameters.AddWithValue("@Idb", book.Idb);
            command.Parameters.AddWithValue("@flyFrom", book.FlyFrom);
            command.Parameters.AddWithValue("@flyTo", book.FlyTo);
            command.Parameters.AddWithValue("@DateFrom", book.Datefrom);
            command.Parameters.AddWithValue("@Peoples", book.Peoples);
            command.Parameters.AddWithValue("@Price", book.Price);
            command.Parameters.AddWithValue("@Users_id", book.Users_id);
            command.Parameters.AddWithValue("@DateOfRes", book.Dateofres);
        }
    }
}
