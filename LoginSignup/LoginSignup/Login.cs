using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginSignup
{
    public partial class Login : Form
    {
        public static string uname="",upass;
        int count = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || username.Text=="username")
            {
                username.Focus();
                error1.SetError(this.username, "Enter your username");
            }
            else if (password.Text == ""||password.Text=="Password")
            {
                password.Focus();
                error1.SetError(this.password, "Enter your password");
            }
            else if(count>0)
            {
                if (count > 0)
                {
                    username.Focus();
                    error1.SetError(this.username, "Invalid Username!!\nIgnore Uppercase");
                }
                else
                {
                    error1.Clear();
                }
            }
            else
            {
                error1.Clear();
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM user_info WHERE username = @UserName AND password = @Password";
                cmd.Parameters.AddWithValue("@UserName", username.Text);
                cmd.Parameters.AddWithValue("@Password", password.Text);
                MySqlDataReader sdr = cmd.ExecuteReader();
                
                if(sdr.Read())
                {
                    con.Close();
                    uname=username.Text;
                    upass=password.Text;
                    this.Hide();
                    ViewTicket.Check(0);
                    MainMenu.Checking(0);
                    new MainMenu().ShowDialog();
                    this.Close();
                }
                else
                {
                    username.Text = "username";
                    username.ForeColor = Color.Silver;
                    password.Text = "Password";
                    password.ForeColor = Color.Silver;
                    MessageBox.Show("Invalid username or password!!");
                }
                //MessageBox.Show("You are loged in..");
                //new Dashboard().Show();
                //this.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                password.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
            }
        }

        private void have_not_account_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignupForm().ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ForgotPassword().ShowDialog();
            
        }

        private void admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().ShowDialog();
            this.Close();
        }

        private void username_Leave(object sender, EventArgs e)
        {
            count = 0;
            if(username.Text=="")
            {
                username.Text = "username";
                username.ForeColor = Color.Silver;
            }
            string str = username.Text;
            char ch;
            int i = str.Length;
            for (int j = 0; j < i; j++)
            {
                ch = str[j];
                if (char.IsUpper(ch))
                {
                    count++;
                }
            }
            
            //if (username.Text == "Username" || username.Text == "")
            //{
            //    username.Focus();
            //    error1.SetError(this.username, "Enter your username");
            //}
            //else
            //{
            //    error1.Clear();
            //}
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
                password.ForeColor = Color.Silver;
            }
            //if (password.Text == "" || password.Text == "Password")
            //{
            //    password.Focus();
            //    error1.SetError(this.password, "Enter your password");
            //}
            //else
            //{
            //    error1.Clear();
            //}
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if(username.Text=="username")
            {
                username.Text = "";
                username.ForeColor = Color.Black;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SupervisorLogin().ShowDialog();
            this.Close();
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
                password.ForeColor = Color.Black;
            }
        }
    }
}
