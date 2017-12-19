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
        static List<FavoriteFligthsSQLMapper> favF = new List<FavoriteFligthsSQLMapper>();
        static Collection<FavoriteFligths> favList = new Collection<FavoriteFligths>();
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

            var usr = UsersSQLMapper.Where(user.Email, user.Password).ToArray();

            if (usr != null)
            {
             foreach (var item in usr)
                {
                    user.Id = item.Id;
                    user.Nick = item.Nick;
                    user.Email = item.Email;
                   
                }


                Session["userID"] = user.Id;
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

            var fav = FavoriteFligthsSQLMapper.getFavFlights((int)Session["userID"]);

            return View(fav);
        }

        [HttpGet]
        public ActionResult setFavFlight(int id) {


            FavoriteFligths favorite = new FavoriteFligths();
            favorite.IdUser= (int)Session["userId"];
            favorite.FlyFrom = letList[id].From;
            favorite.FlyTo = letList[id].To;
            favorite.Datefrom = letList[id].dateFrom;
            favorite.Price = Int32.Parse(letList[id].Cena);

            FavoriteFligthsSQLMapper.Insert(favorite);
            return Redirect("/Home/FavoriteFligths");
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

            return Redirect("/Home/Dashboard");
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