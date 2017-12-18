using MvcFlightFinder.DataMapper;
using MvcFlightFinder.Models;
using MvcFlightFinder.SQLMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        static List<FavFlightsSQLMapper> favF = new List<FavFlightsSQLMapper>();
        static Collection<Favorite_fligths> favList = new Collection<Favorite_fligths>();
        static List<Users> userList = new List<Users>();

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

            var usr = UsersSQLMapper.Where(user.email, user.password).ToArray();

            if (usr != null)
            {
             foreach (var item in usr)
                {
                    user.id = item.id;
                    user.login = item.login;
                    user.email = item.email;
                   
                }


                Session["userID"] = user.id;
                Session["Email"] = user.email.ToString();
                Session["Login"] = user.login.ToString();
                userList.Add(user);
                return Redirect("/Home/Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Login or password incorrected.");
            }
            return View();
        }

        public ActionResult FavoriteFlights() {

            var fav = FavFlightsSQLMapper.getFavFlights((int)Session["userID"]);

            return View(fav);
        }

        [HttpGet]
        public ActionResult setFavFlight(int id) {

           
            Favorite_fligths favorite = new Favorite_fligths();
            favorite.iduser = (int)Session["userId"];
            favorite.flightFrom = letList[id].From;
            favorite.flightTo = letList[id].To;
            favorite.dateFrom = letList[id].dateFrom;
            favorite.price = letList[id].Cena+"Kč";

            FavFlightsSQLMapper.Insert(favorite);
            return Redirect("/Home/FavoriteFlights");
        }

        public ActionResult LogOut() {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return Redirect("/Home/Login");
        }

        public ActionResult Registration()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Registration( string login, string email, string password, string firstName, string lastName)
        {
            

            Users users = new Users();
            users.login = login;
            users.email = email;
            users.password = password;
            users.permision = "u";
            userList.Add(users);
            UsersSQLMapper.Insert(users);

            return Redirect("/Home/Settings");
        }
        public ActionResult Settings() {
            return View();
        }
        [HttpPost]
        public ActionResult Settings(string firstName, string lastName) {

            string email = "";
            string password = "";
            foreach (var item in userList) {
                email = item.email;
                password = item.password;
            }
        var usr = UsersSQLMapper.Where(email, password).ToArray();
          int id = 0;
          foreach (var item in usr) {
              id = item.id;
          }


          Settings set = new Settings();
          set.iduser = id;
          set.password = password;
          set.firstName = firstName;
          set.lastName = lastName;

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
            String urlFlights = "https://api.skypicker.com/flights?flyFrom=" + from + "&to=" + to + "&dateFrom=" + dfrom + "&locale=cz&curr=CZK&sort=price";
            Debug.WriteLine(urlFlights);
            var jFile = client.DownloadString(urlFlights);
          
            JArray jArray = JArray.Parse(@"["+jFile+"]");

            dynamic jItem = JObject.Parse(jFile);
          
            int i = 0;   
            foreach (var item in jItem.data) {
                Lety lety = new Lety();
                lety.Id = i;
                lety.IdCollapse = "collapse"+i.ToString();
                lety.From = (string)item["cityFrom"];
                lety.To = (string)item["cityTo"];
                lety.Cena = (string)item["price"];
                lety.Duration = toHHMMSS((double)item["duration"]["total"]);
                lety.dateFrom = UnixTimeStampToDateTime((double)item["dTime"]);
                lety.Cena = (string)item["price"];
                letList.Add(lety);

                i++;
            }
            
            ViewBag.setRoutes = jItem.data;
            return letList;
        }

        public string timeSpanToDate() {

            return "";
        }

        public ActionResult Delete() {

            return View();
        }
        public ActionResult Delete(int id)
        {

            return View();
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