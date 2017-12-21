using DBHandler.DataMapper;
using DBHandler.SQLMapper;
using FlightForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightForms
{
    public partial class Login : Form
    {
        static List<Users> listUser = new List<Users>();
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            var usr = UsersSQLMapper.Where(textBox1.Text, textBox2.Text).ToArray();

            if (usr != null)
            {
                foreach (var item in usr)
                {
                    user.Id = item.Id;
                    user.Nick = item.Nick;
                    user.Email = item.Email;
                    user.Firstname = item.Firstname;
                    user.Lastname = item.Lastname;
                }
                listUser.Add(user);
                Dashboard dash = new Dashboard();
                dash.listUser = listUser;
                dash.Show();
                this.Hide();
            }
        }
    }
}
