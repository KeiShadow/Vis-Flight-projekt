using DBHandler.DataMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightForms.Forms
{
    public partial class Dashboard : Form
    {
        int id = 0;
        public  List<Users> listUser { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            foreach (var item in listUser) {
                id = item.Id;

            }
            //var getfav = 
        }

     
    }
}
