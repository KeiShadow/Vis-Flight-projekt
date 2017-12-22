
using GMap.NET;
using GMap.NET.WindowsForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightFroms.Forms
{
    public partial class FindFlight : Form
    {

        public  static List<Lety> letList = new List<Lety>();
        public int idselected;

        public FindFlight()
        {
            InitializeComponent();

            tb_From.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_To.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb_From.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_To.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection cFromTo = new AutoCompleteStringCollection();
            JsonParser jparser = new JsonParser();
            foreach (var item in jparser.getPlaces()) {
                if (item.type == "2") {
                    cFromTo.Add(item.value);
                }

            }
            tb_From.AutoCompleteCustomSource = cFromTo;
            tb_To.AutoCompleteCustomSource = cFromTo;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            if (tb_From.Text != "" || tb_To.Text != "" || dt_Dep.Text != "") {
                String urlFlights = "https://api.skypicker.com/flights?flyFrom=" + tb_From.Text + "&to=" + tb_To.Text + "&dateFrom=" + getDate(dt_Dep) + "&locale=cz&curr=CZK&sort=price&limit=20";
                var jFile = client.DownloadString(urlFlights);

                JArray jArray = JArray.Parse(@"[" + jFile + "]");

                dynamic jItem = JObject.Parse(jFile);
                int i = 0;
                idselected = 0;
                foreach (var item in jItem.data)
                {
                    Lety lety = new Lety();
                    lety.Id = i;
                    lety.From = (string)item["cityFrom"];
                    lety.To = (string)item["cityTo"];
                    lety.Cena = item["price"];
                    lety.Duration = toHHMMSS((double)item["duration"]["total"]);
                    lety.dateFrom = UnixTimeStampToDateTime((double)item["dTime"]);
                    letList.Add(lety);

                   

                    ListViewItem lvi = new ListViewItem(i.ToString());
                    lvi.SubItems.Add((string)item["cityFrom"]);
                    lvi.SubItems.Add((string)item["cityTo"]);
                    lvi.SubItems.Add(UnixTimeStampToDateTime((double)item["dTime"]));
                    lvi.SubItems.Add(toHHMMSS((double)item["duration"]["total"]));
                    lvi.SubItems.Add(item["price"].ToString());
                    listResult.Items.Add(lvi);
                    i++;
                    idselected++;
                }
            }
        }  

        public string toHHMMSS(double sec)
        {
            TimeSpan time = TimeSpan.FromSeconds(sec);
            string str = time.ToString(@"hh\:mm");
            return str;
        }
        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString();
        }
        public string getDate(DateTimePicker dtp) {
            return dtp.Value.Date.Day + "/" + dtp.Value.Date.Month + "/" + dtp.Value.Date.Year;
        }

        private void listResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                   ;

                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Reservration reservration = new Reservration();
            reservration.idselected = int.Parse(listResult.FocusedItem.Text);
            reservration.Show();
        }
    }
}
