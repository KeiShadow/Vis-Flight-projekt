using MvcFlightFinder.DataMapper;
using MvcFlightFinder.Models;
using MvcFlightFinder.SQLMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace MvcFlightFinder.Controllers
{
    public class HomeController : Controller
    {
        static List<Location> locList = new List<Location>();
        static List<Lety> letList = new List<Lety>();
        static List<Form> formList = new List<Form>();
        static List<Users> userList = new List<Users>();

        static Collection<FavoriteFligths> favList = new Collection<FavoriteFligths>();        
        static Collection<BookedFlights> bookList = new Collection<BookedFlights>();

        public ActionResult findFlights()
        {
            ViewBag.Lokace = getPlaces();
            return View();
        }

        [HttpPost]
        public ActionResult findFlights(String srchFrom, String srchTo, string dateFrom)
        {
            letList.Clear();
            if (srchFrom != "" && srchTo != "" && dateFrom != "")
            {
                ViewBag.Lokace = getPlaces();
                Form form = new Form();

                form.srchFrom = srchFrom;
                form.srchTo = srchTo;
                form.dateFrom = dateFrom;

                formList.Add(form);

                return Redirect("/Home/Detail");

            }
            else {
                return View();
            }
        }

        public ActionResult Detail()
        {
            if (getFlights().Count != 0) {
                return View(getFlights());
            }
            ViewBag.Warn = "Nemáte žádné zakoupené letenky";
            return View(getFlights());
        }


        public ActionResult Dashboard() {

            return View();
        }

        public ActionResult Login() {

            return View();
        }
        /*Login sekce*/
        [HttpPost]
        public ActionResult Login(Users user)
        {

            var usr = UsersSQLMapper.Where(user.Email, user.Password).ToArray();

            if (usr != null )
            {
             foreach (var item in usr)
                {
                    user.Id = item.Id;
                    user.Nick = item.Nick;
                    user.Email = item.Email;
                    user.Firstname = item.Firstname;
                    user.Lastname = item.Lastname;

                }


                Session["Id"] = user.Id;
                Session["Email"] = user.Email.ToString();
                Session["Login"] = user.Nick.ToString();
                
                userList.Add(user);
                return Redirect("/Home/Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Email or password incorrected.");
            }
            return View();
        }

        public ActionResult FavoriteFligths() {
            var fav = FavoriteFligthsSQLMapper.getFavFlights((int)Session["Id"]);
           if (fav.Count != 0)
            {
               return View(fav);
            }
            ViewBag.Warn = "Nemáte žádné oblíbené lety!";
            return View(fav);
        }

        [HttpGet]
        public ActionResult setFavFlight(int id) {


            FavoriteFligths favorite = new FavoriteFligths();
            favorite.IdUser= (int)Session["userId"];
            favorite.FlyFrom = letList[id].From;
            favorite.FlyTo = letList[id].To;
            favorite.Datefrom = letList[id].dateFrom;
            favorite.Price = letList[id].Cena;

            FavoriteFligthsSQLMapper.Insert(favorite);
            return Redirect("/Home/FavoriteFligths");
        }

        public ActionResult LogOut() {
            int userID = (int)Session["Id"];
            Session.Abandon();
            return Redirect("/Home/Login");
        }

        public ActionResult Registration()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Registration( string Nick, string email, string password, string firstName, string lastName)
        {
            

            Users users = new Users();
            users.Nick = Nick;
            users.Email = email;
            users.Password = password;
            users.Firstname = firstName;
            users.Lastname = lastName;

            userList.Add(users);
            UsersSQLMapper.Insert(users);

            return Redirect("/Home/Login");
        }
        

        public string getPlaces()
        {
            using (StreamReader r = new StreamReader(@"D:\GitHub\Vis-Flight-projekt\MvcFlightFinder\MvcFlightFinder\App_Data\places.json"))
            {
                string json = r.ReadToEnd();
                locList = JsonConvert.DeserializeObject<List<Location>>(json);
            }

            string locations = "[";
            foreach (var item in locList)
            {
                if (item.lat != null && item.lng != null && item.type == "2")
                {
                    locations += "{id: \"" + item.id + "\",value: \"" + item.value + "\",lat: " + item.lat + ",lng: " + item.lng + "},";
                }
            }

            locations += "]";

            return locations;
        }


        public List<Lety> getFlights() {

            ViewBag.LokMapa = getPlaces();
            WebClient client = new WebClient();

            string from = "";
            string to = "";
            string dfrom = "";

            foreach (var fitem in formList) {
                from = fitem.srchFrom;
                to = fitem.srchTo;
                dfrom = fitem.dateFrom;
            }
            if (from != "" || dfrom != "" || to != "") {
                String urlFlights = "https://api.skypicker.com/flights?flyFrom=" + from + "&to=" + to + "&dateFrom=" + dfrom + "&locale=cz&curr=CZK&sort=price&limit=20";


                var jFile = client.DownloadString(urlFlights);

                JArray jArray = JArray.Parse(@"[" + jFile + "]");

                dynamic jItem = JObject.Parse(jFile);
                List<int> ids = new List<int>();
                int i = 0;
                string id = "[" + i;

                foreach (var item in jItem.data)
                {


                    Lety lety = new Lety();
                    lety.Id = i;
                    lety.IdCollapse = "collapse" + i.ToString();
                    lety.From = (string)item["cityFrom"];
                    lety.To = (string)item["cityTo"];
                    lety.Cena = item["price"];
                    lety.Duration = toHHMMSS((double)item["duration"]["total"]);
                    lety.dateFrom = UnixTimeStampToDateTime((double)item["dTime"]);
                    letList.Add(lety);

                    i++;
                    id += "," + i;
                }
                id += "]";
                ViewBag.setId = id;
                ViewBag.setRoutes = jItem.data;
                return letList;
            }
            return letList;
        }

        public string timeSpanToDate() {

            return "";
        }

        public ActionResult Delete(int id)
        {

            return View();
        }

        public ActionResult Booking(int id) {
            string firstName = "";
            string lastName = "";

            ViewBag.from = letList[id].From;
            ViewBag.To = letList[id].To;
            ViewBag.Cena = letList[id].Cena.ToString();
            foreach (var item in userList) {
                firstName = item.Firstname;
                lastName = item.Lastname;

            }
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;

            return View();
        }

        [HttpPost]
        public ActionResult Booking(int id, string LastName, string FirstName, int Peoples, string Gender ) {
          
            BookedFlights booked = new BookedFlights();
            booked.Users_id = (int)Session["Id"];
            booked.FirstName = FirstName;
            booked.LastName = LastName;
            booked.FlyFrom = letList[id].From;
            booked.FlyTo = letList[id].To;
            booked.Datefrom = letList[id].dateFrom;
            booked.Dateofres = DateTime.Today.ToString();
            booked.Peoples = Peoples;
            booked.Price = letList[id].Cena;
            booked.Gender = Gender;

           

            BookedFlightsSQLMapper.Insert(booked);
            return Redirect("/Home/BookedList");
        }
        public ActionResult BookedList()
        {
            var booked = BookedFlightsSQLMapper.getBookedList((int)Session["Id"]);
            if(booked.Count != 0)
            {
                return View(booked);
            }
            ViewBag.Warn = "Nemáte žádné zakoupené letenky";
            return View(booked);
        }
        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();         
            return dtDateTime.ToString();
        }

        public string toHHMMSS(double sec)
        {
            TimeSpan time = TimeSpan.FromSeconds(sec);
            string str = time.ToString(@"hh\:mm");
            return str;
        }

    }
}