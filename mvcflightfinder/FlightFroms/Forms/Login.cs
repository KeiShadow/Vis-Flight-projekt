using DBHandler.DataMapper;
using DBHandler.SQLMapper;
using FlightFroms.Forms;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Windows.Forms;

namespace FlightForms
{
    public partial class Login : Form
    {
        public static List<Users> listUsers = new List<Users>();
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

                listUsers.Add(user);
                 Dashboard dash = new Dashboard();
                dash.Show();
                this.Hide();
            }
        }
    }
}
