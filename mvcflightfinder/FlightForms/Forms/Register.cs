using DBHandler.DataMapper;
using DBHandler.SQLMapper;
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
    public partial class Register : Form
    {
        
        public Register()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Nick = tb_nick.Text;
            users.Email = tb_email.Text;
            users.Password = tb_pass.Text;
            users.Firstname = tb_firstname.Text;
            users.Lastname = tb_lastname.Text;

            UsersSQLMapper.Insert(users);

            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
