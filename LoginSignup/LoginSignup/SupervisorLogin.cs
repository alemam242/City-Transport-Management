using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSignup
{
    public partial class SupervisorLogin : Form
    {
        public static string superid = "";
        public SupervisorLogin()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || username.Text == "User Id")
            {
                username.Focus();
                error1.SetError(this.username, "Enter your User Id");
            }
            else if (password.Text == "" || password.Text == "Password")
            {
                password.Focus();
                error1.SetError(this.password, "Enter your password");
            }
            else
            {
                error1.Clear();
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM supervisor_info WHERE superviser_id = @UserName AND pass = @Password";
                cmd.Parameters.AddWithValue("@UserName", username.Text);
                cmd.Parameters.AddWithValue("@Password", password.Text);
                MySqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    con.Close();
                    superid = username.Text;
                    this.Hide();
                    new SuperviserPanel().ShowDialog();
                    this.Close();
                }
                else
                {
                    username.Text = "User Id";
                    username.ForeColor = Color.Silver;
                    password.Text = "Password";
                    password.ForeColor = Color.Silver;
                    MessageBox.Show("Invalid user id or password!!");
                }
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "User Id";
                username.ForeColor = Color.Silver;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
                password.ForeColor = Color.Silver;
            }
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "User Id")
            {
                username.Text = "";
                username.ForeColor = Color.Black;
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

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
