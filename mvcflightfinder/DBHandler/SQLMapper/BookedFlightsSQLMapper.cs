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
    public class BookedFlightsSQLMapper
    {
        public static string SQL_SINGLE_SELECT = "SELECT * FROM BookedFlights WHERE Users_id = @Users_id";
        public static string SQL_INSERT = "INSERT INTO BookedFlights VALUES (@flyFrom, @flyTo, @DateFrom,@Peoples, @Price,@Users_id,@DateOfRes,@LastName,@FirstName,@Gender)";
        public static string SQL_DELETE = "DELETE FROM BookedFlights WHERE Idb =@Users_id";

        public static List<BookedFlights> favFlight { get => favFlight; set => favFlight = value; }

        public static int Insert(BookedFlights booked)
        {

            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, booked);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static int Delete(int id)
        {

            Database db;
            db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();

            return ret;
        }

        public static Collection<BookedFlights> getBookedList(int id)
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
                book.Datefrom = reader.GetString(++i);
                book.Peoples = reader.GetInt32(++i);
                book.Price = reader.GetInt32(++i);
                book.Users_id = reader.GetInt32(++i);
                book.Dateofres = reader.GetString(++i);
                book.LastName = reader.GetString(++i);
                book.FirstName = reader.GetString(++i);
                book.Gender = reader.GetString(++i);

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
            command.Parameters.AddWithValue("@LastName", book.LastName);
            command.Parameters.AddWithValue("@FirstName", book.FirstName);
            command.Parameters.AddWithValue("@Gender", book.Gender);

        }

     
    }
}
