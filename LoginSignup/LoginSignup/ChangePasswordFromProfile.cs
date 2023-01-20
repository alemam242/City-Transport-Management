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
    public partial class ChangePasswordFromProfile : Form
    {
        public ChangePasswordFromProfile()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Hide();
            //new MainMenu().ShowDialog();
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
                cmd.Parameters.AddWithValue("@UserName", Login.uname);
                cmd.Parameters.AddWithValue("@Password", re_password.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password Reset Successfull");
                this.Close();
                //new Login().ShowDialog();
                //this.Hide();
            }
            else
            {
                new_password.Text = "";
                re_password.Text = "";
                MessageBox.Show("Entered Wrong Password");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
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

        private void ChangePasswordFromProfile_Load(object sender, EventArgs e)
        {

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
