using DBHandler.DataMapper;
using DBHandler.SQLMapper;
using FlightForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FlightFroms.Forms
{
    public partial class Dashboard : Form
    {
        int id = 0;
        string Nick = "";
        static Collection<FavoriteFligths> listFav;
        static Collection<BookedFlights> listBooked;
          
        public Dashboard()
        {
            InitializeComponent();
            foreach (var item in Login.listUsers) {
                id = item.Id;
                Nick = item.Nick;
            }
            labelNick.Text = Nick;
            listFav = FavoriteFligthsSQLMapper.getFavFlights(id);
            dataGridView1.DataSource = listFav;

            listBooked = BookedFlightsSQLMapper.getBookedList(id);
            dataGridView2.DataSource = listBooked;

            var deleteButtonFav = new DataGridViewButtonColumn();
            deleteButtonFav.Name = "dataGridViewDeleteButton";
            deleteButtonFav.HeaderText = "Delete";
            deleteButtonFav.Text = "Delete";
            deleteButtonFav.UseColumnTextForButtonValue = true;
            this.dataGridView1.Columns.Add(deleteButtonFav);

            var deleteButtonRes = new DataGridViewButtonColumn();
            deleteButtonRes.Name = "dataGridView2DeleteButton";
            deleteButtonRes.HeaderText = "Delete";
            deleteButtonRes.Text = "Delete";
            deleteButtonRes.UseColumnTextForButtonValue = true;
            this.dataGridView2.Columns.Add(deleteButtonRes);

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                //Put some logic here, for example to remove row from your binding list.
                foreach (var item in listFav) {
                    id = item.Idf;
                }
                FavoriteFligthsSQLMapper.Delete(id);
               
            }
        }

        private void bt_RefreshFav_Click(object sender, EventArgs e)
        {
            Collection<FavoriteFligths> listFav = FavoriteFligthsSQLMapper.getFavFlights(id);
            dataGridView1.DataSource = listFav;

            Collection<BookedFlights> listBooked = BookedFlightsSQLMapper.getBookedList(id);
            dataGridView2.DataSource = listBooked;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dataGridView2.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dataGridView2.Columns["dataGridView2DeleteButton"].Index)
            {
                //Put some logic here, for example to remove row from your binding list.
                foreach (var item in listBooked)
                {
                    id = item.Idb;
                }
                BookedFlightsSQLMapper.Delete(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindFlight findFlight = new FindFlight();
            findFlight.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login.listUsers.Clear();
            Dashboard.listBooked.Clear();
            Dashboard.listFav.Clear();
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
