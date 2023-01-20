using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace LoginSignup
{
    public partial class ForgotPassword : Form
    {
        public static string uname,gmail;
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        public ForgotPassword()
        {
            InitializeComponent();
            label1.Text = "Username";
            label2.Text = "Search by email";
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Username" && username.Text == "")
            {
                username.Focus();
                error1.SetError(this.username, "Enter your username");
            }
            else if((label1.Text == "Email" && Regex.IsMatch(username.Text, pattern)==false) || username.Text == "")
            {
                username.Focus();
                error1.SetError(this.username, "Enter your valid email");
            }
            else
            {
                bool res = search_result();
                if (res)
                {
                    uname = username.Text;
                    this.Hide();
                    new Reset_Password().ShowDialog();
                    //this.Hide();
                }
                else
                {
                    username.Text = "";
                    if (label1.Text == "Username")
                    {
                        MessageBox.Show("Don't Have Any Account With This Username");
                    }
                    else
                    {
                        MessageBox.Show("Don't Have Any Account With This mail");
                    }
                }
            }
        }

        public bool search_result()
        {
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            MySqlDataReader sdr;
            if (label1.Text == "Username")
            {
                cmd.CommandText = "SELECT email FROM user_info WHERE username = @UserName";
            }
            else
            {
                cmd.CommandText = "SELECT email FROM user_info WHERE username = @UserName";
            }
            cmd.Parameters.AddWithValue("@UserName", username.Text);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                gmail=sdr["email"].ToString();
                //string p = sdr["password"].ToString();
                //MessageBox.Show(sdr["password"].ToString(), "The password is");
                //con.Close();
                //this.Hide();
                //new Form1().Show();
                return true;
            }
            else
            {
                //MessageBox.Show("Username doesn't match");
                return false;
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (label1.Text == "Username")
            {
                if (username.Text == "")
                {
                    username.Focus();
                    error1.SetError(this.username, "Enter your username");
                }
                else
                {
                    error1.Clear();
                }
            }
            else
            {
                if (username.Text == "" || Regex.IsMatch(username.Text, pattern)==false)
                {
                    username.Focus();
                    error1.SetError(this.username, "Enter valid mail");
                }
                else
                {
                    error1.Clear();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Username")
            {
                label1.Text = "Email";
                label2.Text = "Search by username";
                //label2.Location = new Point(199, 417);
            }
            else if(label1.Text == "Email")
            {
                label1.Text = "Username";
                label2.Text = "Search by email";
                //label2.Location = new Point(223, 417);
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            //this.Hide();
        }
    }
}
