using DBHandler.DataMapper;
using DBHandler.SQLMapper;
using FlightForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightFroms.Forms
{
    public partial class Reservration : Form
    {
        public int idselected { get; set; }
        int idUs = 0;
        
        public Reservration()
        {
            InitializeComponent();

            lcena.Text = FindFlight.letList[idselected].Cena.ToString();
            fromTo.Text = FindFlight.letList[idselected].From+" -> "+FindFlight.letList[idselected].To;
            foreach (var item in Login.listUsers) {
                idUs = item.Id;
                tb_FrstName.Text = item.Firstname;
                tb_LastName.Text = item.Lastname;
            }
            


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void nupPeoples_ValueChanged(object sender, EventArgs e)
        {
            lcena.Text = (FindFlight.letList[idselected].Cena*nupPeoples.Value).ToString();
        }

        private void bt_Pay_Click(object sender, EventArgs e)
        {
                BookedFlights booked = new BookedFlights();
                booked.Users_id = idUs;
                booked.FirstName = tb_FrstName.Text;
                booked.LastName = tb_LastName.Text;
                booked.FlyFrom = FindFlight.letList[idselected].From;
                booked.FlyTo = FindFlight.letList[idselected].To;
                booked.Datefrom = FindFlight.letList[idselected].dateFrom;
                booked.Dateofres = DateTime.Today.ToString();
                booked.Peoples = (int)nupPeoples.Value;
                booked.Price = int.Parse(lcena.Text);
                booked.Gender = cbGender.SelectedItem.ToString();
            
            BookedFlightsSQLMapper.Insert(booked);

        }
    }
}
