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
    public partial class change_password : Form
    {
        public change_password()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                new_password.PasswordChar = '\0';
                re_password.PasswordChar = '\0';
            }
            else
            {
                new_password.PasswordChar = '*';
                re_password.PasswordChar = '*';
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            if (new_password.Text == re_password.Text)
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE user_info SET password = @Password WHERE username = @Username";
                cmd.Parameters.AddWithValue("@UserName", ForgotPassword.uname);
                cmd.Parameters.AddWithValue("@Password", re_password.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password Reset Successfull");
                this.Hide();
                new Login().ShowDialog();
                //this.Hide();
            }
            else
            {
                new_password.Text = "";
                re_password.Text = "";
                MessageBox.Show("Entered Wrong Password");
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Reset_Password().ShowDialog();
            //this.Hide();
        }

        private void new_password_Leave(object sender, EventArgs e)
        {
            if (new_password.Text == "")
            {
                new_password.Focus();
                error1.SetError(this.new_password, "Set a strong password");
            }
            else
            {
                error1.Clear();
            }
        }

        private void re_password_Leave(object sender, EventArgs e)
        {
            if (re_password.Text == "")
            {
                re_password.Focus();
                error1.SetError(this.re_password, "Enter same password");
            }
            else if(re_password.Text != new_password.Text)
            {
                re_password.Focus();
                error1.SetError(this.re_password, "Password not matching");
            }
            else
            {
                error1.Clear();
            }
        }

        private void new_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void re_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
