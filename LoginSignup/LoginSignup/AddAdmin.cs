using MySql.Data.MySqlClient;
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

namespace LoginSignup
{
    public partial class AddAdmin : Form
    {
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        static int code;
        string UserN;
        public AddAdmin()
        {
            InitializeComponent();
            if (code == 1)
            {
                nametxt.Text = AdminPanel.v5;
                usernametxt.Text = AdminPanel.v2;
                passwordtxt.Text = AdminPanel.v3;
                UserN = AdminPanel.v2;
                codetxt.Text = AdminPanel.v1;
                mailtxt.Text = AdminPanel.v4;
            }
        }
        private void clr_btn_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void ResetData()
        {
            nametxt.Text = "";
            usernametxt.Text = "";
            passwordtxt.Text = "";
            codetxt.Text = "";
            mailtxt.Text = "";
        }
        public static void Check(int a)
        {
            code = a;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string rndname = usernametxt.Text + r.Next(199).ToString();
            if (code == 0)
            {
                if (nametxt.Text == "")
                {
                    nametxt.Focus();
                    error.SetError(this.nametxt, "Enter your name");
                }
                else if (usernametxt.Text == "")
                {
                    usernametxt.Focus();
                    error.SetError(this.usernametxt, "Enter username");
                }
                else if (passwordtxt.Text == "")
                {
                    passwordtxt.Focus();
                    error.SetError(this.passwordtxt, "Enter password");
                }
                else if (codetxt.Text == "")
                {
                    codetxt.Focus();
                    error.SetError(this.codetxt, "Enter code");
                }
                else if (mailtxt.Text == "")
                {
                    mailtxt.Focus();
                    error.SetError(this.mailtxt, "Enter your mail");
                }
                else if (Regex.IsMatch(mailtxt.Text, pattern) == false)
                {
                    mailtxt.Focus();
                    error.SetError(this.mailtxt, "Invalid mail");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM admin_info WHERE username = @US";
                    cmd.Parameters.AddWithValue("@US",usernametxt.Text);
                    MySqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        con.Close();
                        MessageBox.Show("This username already exists!\nTry different username\nYou can use " + rndname);
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        try
                        {
                            cmd.CommandText = "INSERT INTO admin_info(Name,username,password,code,email) VALUES (@name,@UserName,@Password,@Code,@Email)";
                            cmd.Parameters.AddWithValue("@name", nametxt.Text);
                            cmd.Parameters.AddWithValue("@UserName", usernametxt.Text);
                            cmd.Parameters.AddWithValue("@Password", passwordtxt.Text);
                            cmd.Parameters.AddWithValue("@Code", codetxt.Text);
                            cmd.Parameters.AddWithValue("@Email", mailtxt.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Data Inserted");
                            ResetData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Data cann't be Inserted\n" + ex);
                        }
                    }
                }
            }
            else
            {
                if (codetxt.Text == AdminPanel.v1 && usernametxt.Text == AdminPanel.v2 && passwordtxt.Text == AdminPanel.v3
                    && mailtxt.Text == AdminPanel.v4 && nametxt.Text == AdminPanel.v5)
                {
                    MessageBox.Show("Change something to update the record");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    try
                    {
                        cmd.CommandText = "UPDATE admin_info SET Name = @name, username = @UserName, password = @Password, code  = @Code, email = @Email WHERE username = @US";
                        cmd.Parameters.AddWithValue("@name", nametxt.Text);
                        cmd.Parameters.AddWithValue("@UserName", usernametxt.Text);
                        cmd.Parameters.AddWithValue("@Password", passwordtxt.Text);
                        cmd.Parameters.AddWithValue("@Code", codetxt.Text);
                        cmd.Parameters.AddWithValue("@Email", mailtxt.Text);
                        cmd.Parameters.AddWithValue("@US", UserN);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data Updated");
                        ResetData();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data cann't be Updated\n" + ex);
                    }
                }
            }
        }
        private void nametxt_Leave(object sender, EventArgs e)
        {
            if (nametxt.Text == "")
            {
                nametxt.Focus();
                error.SetError(this.nametxt, "Enter name");
            }
            else
            {
                char tmp = nametxt.Text[0];
                if (char.IsUpper(tmp))
                {
                    error.Clear();
                }
                else
                {
                    nametxt.Focus();
                    error.SetError(this.nametxt, "First letter must be capital");
                }
            }
        }

        private void usernametxt_Leave(object sender, EventArgs e)
        {
            if (usernametxt.Text == "")
            {
                usernametxt.Focus();
                error.SetError(this.usernametxt, "Enter username");
            }
            else
            {
                string tmp = usernametxt.Text;
                char c;
                int i, count = 0;
                for(i=0;i< tmp.Length; i++)
                {
                    c = tmp[i];
                    if(char.IsUpper(c))
                    {
                        count++;
                    }
                }
                if(count>0)
                {
                    usernametxt.Focus();
                    error.SetError(this.usernametxt, "username must be in small letter");
                }
                else
                {
                    error.Clear();
                }
            }
        }

        private void passwordtxt_Leave(object sender, EventArgs e)
        {
            if (passwordtxt.Text == "")
            {
                passwordtxt.Focus();
                error.SetError(this.passwordtxt, "Enter password");
            }
            else
            {
                error.Clear();
            }
        }

        private void codetxt_Leave(object sender, EventArgs e)
        {
            if (codetxt.Text == "")
            {
                codetxt.Focus();
                error.SetError(this.codetxt, "Set code");
            }
            else
            {
                error.Clear();
            }
        }

        private void mailtxt_Leave(object sender, EventArgs e)
        {
            if (mailtxt.Text == "")
            {
                mailtxt.Focus();
                error.SetError(this.mailtxt, "Enter valid email");
            }
            else
            {
                error.Clear();
            }
        }
    }
}
