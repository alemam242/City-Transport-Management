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
    public partial class EditProfile : Form
    {
        string n, g, u, em,gend;

        private void bck_btn_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //new MainMenu().ShowDialog();
            this.Close();
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if ((name.Text == n || name.Text == "") && (username.Text == u || username.Text == "") && (gmail.Text == em || gmail.Text == ""))
            {
                save_btn.Visible = false;
            }
            else
            {
                save_btn.Visible = true;
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if ((name.Text == n || name.Text == "") && (username.Text == u || username.Text == "") && (gmail.Text == em || gmail.Text == ""))
            {
                save_btn.Visible = false;
            }
            else
            {
                save_btn.Visible = true;
            }
        }

        private void gmail_Leave(object sender, EventArgs e)
        {
            if ((name.Text == n || name.Text=="") && (username.Text == u  || username.Text == "") && (gmail.Text == em || gmail.Text==""))
            {
                save_btn.Visible = false;
            }
            else
            {
                save_btn.Visible = true;
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("After Changes You will be Loged out.\nApply Changes ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE user_info SET Name = @name, gender=@Gen, username = @UserName, email=@Gmail WHERE username = @User";
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@Gen", g);
                cmd.Parameters.AddWithValue("@UserName", username.Text);
                cmd.Parameters.AddWithValue("@Gmail", gmail.Text);
                cmd.Parameters.AddWithValue("@User", Login.uname);
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                new Login().ShowDialog();
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if ((name.Text == n || name.Text == "") && (username.Text == u || username.Text == "") && (gmail.Text == em || gmail.Text == ""))
            {
                save_btn.Visible = false;
            }
            else
            {
                save_btn.Visible = true;
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            if ((name.Text == n || name.Text == "") && (username.Text == u || username.Text == "") && (gmail.Text == em || gmail.Text == ""))
            {
                save_btn.Visible = false;
            }
            else
            {
                save_btn.Visible = true;
            }
        }

        private void gmail_TextChanged(object sender, EventArgs e)
        {
            if ((name.Text == n || name.Text == "") && (username.Text == u || username.Text == "") && (gmail.Text == em || gmail.Text == ""))
            {
                save_btn.Visible = false;
            }
            else
            {
                save_btn.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                gend = "Male";
                if(g!=gend)
                {
                    save_btn.Visible = true;
                }
                else
                {
                    save_btn.Visible=false;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                gend = "Female";
                if (g != gend)
                {
                    save_btn.Visible = true;
                }
                else
                {
                    save_btn.Visible = false;
                }
            }
        }

        public EditProfile()
        {
            InitializeComponent();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            editinfo();
        }

        private void editinfo()
        {
            if (SignupForm.uname == "")
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM user_info WHERE username = @UserName";
                cmd.Parameters.AddWithValue("@UserName", Login.uname);
                MySqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    name.Text = sdr["Name"].ToString();
                    g = sdr["gender"].ToString();
                    username.Text = sdr["username"].ToString();
                    gmail.Text = sdr["email"].ToString();
                    n = sdr["Name"].ToString();
                    gend = sdr["gender"].ToString();
                    u = sdr["username"].ToString();
                    em = sdr["email"].ToString();
                    save_btn.Visible = false;
                    if (gend == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
            else
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM user_info WHERE username = @UserName";
                cmd.Parameters.AddWithValue("@UserName", SignupForm.uname);
                MySqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    name.Text = sdr["Name"].ToString();
                    g = sdr["gender"].ToString();
                    username.Text = sdr["username"].ToString();
                    gmail.Text = sdr["email"].ToString();
                    n = sdr["Name"].ToString();
                    gend = sdr["gender"].ToString();
                    u = sdr["username"].ToString();
                    em = sdr["email"].ToString();
                    save_btn.Visible = false;
                    if (gend == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
        }
    }
}
