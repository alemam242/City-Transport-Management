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
    public partial class SignupForm : Form
    {
        //gmail pattern
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string pass = "^[a-zA-Z0-9]{5,}$";
        string gend = "";
        public static string uname="";
        public SignupForm()
        {
            InitializeComponent();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (set_name.Text == "" || set_password.Text=="Full Name")
            {
                set_name.Focus();
                error1.SetError(this.set_name, "Fill the name field correctly");
            }
            else if (set_username.Text == "" || set_username.Text=="username")
            {
                set_username.Focus();
                error2.SetError(this.set_username, "set a username");
            }
            else if (set_email.Text == "" || Regex.IsMatch(set_email.Text, pattern) == false || set_email.Text=="abc@gmail.com")
            {
                set_email.Focus();
                error3.SetError(this.set_email, "Enter your valid mail");
            }
            else if (set_password.Text == "" || set_password.Text=="Password" || Regex.IsMatch(set_password.Text,pass)==false)
            {
                set_password.Focus();
                error4.SetError(this.set_password, "set a strong password\nMinimum 5 Characters");
            }
            else if (con_password.Text=="Password" || con_password.Text.Length < set_password.Text.Length || con_password.Text != set_password.Text || con_password.Text.Length > set_password.Text.Length)
            {
                con_password.Focus();
                con_password.BackColor = Color.Gray;
                error5.SetError(this.con_password, "Password is not matching");
            }
            else if(gend=="")
            {
                Gender.Focus();
                error7.SetError(this.Gender, "Select your gender");
            }
            else
            {
                if (set_password.Text == con_password.Text)
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT username from user_info WHERE username = @UserName";
                    cmd.Parameters.AddWithValue("@UserName", set_username.Text);
                    MySqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        con.Close();
                        set_username.BackColor = Color.Gray;
                        Random rand = new Random();
                        string name = set_username.Text + rand.Next(199).ToString();
                       
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT username from user_info WHERE username = @UserName";
                        cmd.Parameters.AddWithValue("@UserName", name);
                        MySqlDataReader sdr2 = cmd.ExecuteReader();
                        if (sdr2.Read())
                        {
                            MessageBox.Show("Enter another username\nYou can use " + name + "0");
                        }
                        else
                        {
                            MessageBox.Show("Enter another username\nYou can use " + name);
                        }
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        set_username.BackColor = Color.White;
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT INTO user_info(name,gender,username,password,email) VALUES (@Name,@Gen,@AnotherUserName,@Password,@Email)";
                        cmd.Parameters.AddWithValue("@Name", set_name.Text);
                        cmd.Parameters.AddWithValue("@Gen", Gender.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@AnotherUserName", set_username.Text);
                        cmd.Parameters.AddWithValue("@Password", con_password.Text);
                        cmd.Parameters.AddWithValue("@Email", set_email.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        uname=set_username.Text;
                        MessageBox.Show("Account Created..");
                        this.Hide();
                        ViewTicket.Check(1);
                        MainMenu.Checking(1);
                        new MainMenu().ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Password !");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                set_password.PasswordChar = '\0';
                con_password.PasswordChar = '\0';
            }
            else
            {
                set_password.PasswordChar = '*';
                con_password.PasswordChar = '*';
            }
        }

        private void have_account_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            //this.Hide();
        }

        private void con_password_Leave(object sender, EventArgs e)
        {
            if(con_password.Text.Length < set_password.Text.Length || con_password.Text != set_password.Text || con_password.Text.Length > set_password.Text.Length)
            {
                con_password.Focus();
                con_password.BackColor = Color.Gray;
                error5.SetError(this.con_password, "Password is not matching");
            }
            else
            {
                con_password.BackColor= Color.White;
                error5.Clear();
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            //this.Hide();
        }

        private void set_name_Leave(object sender, EventArgs e)
        {
            
            if (set_name.Text=="")
            {
                set_name.Focus();
                error1.SetError(this.set_name,"Fill the name field");
            }
            else
            {
                char tmp = set_name.Text[0];
                if(char.IsUpper(tmp))
                {
                    error1.Clear();
                }
                else
                {
                    set_name.Focus();
                    error1.SetError(this.set_name, "First letter must be capital");
                }
            }
        }

        private void set_username_Leave(object sender, EventArgs e)
        {
            if (set_username.Text == "")
            {
                set_username.Focus();
                error2.SetError(this.set_username, "set a username");
            }
            else
            {
                string str = set_username.Text;
                char ch;
                int i = str.Length,count=0;
                for(int j = 0; j < i; j++)
                {
                    ch= str[j];
                    if(char.IsUpper(ch))
                    {
                        count++;
                    }
                }
                if(count>0)
                {
                    set_username.Focus();
                    error2.SetError(this.set_username, "Ignore Uppercase");
                }
                else
                {
                    error2.Clear();
                }
            }
        }

        private void set_email_Leave(object sender, EventArgs e)
        {
            if (set_email.Text=="" || Regex.IsMatch(set_email.Text,pattern)==false)
            {
                set_email.Focus();
                error3.SetError(this.set_email, "Enter your valid mail");
            }
            else
            {
                error3.Clear();
            }
        }

        private void set_password_Leave(object sender, EventArgs e)
        {
            if (set_password.Text == "")
            {
                set_password.Focus();
                error4.SetError(this.set_password, "set a strong password\nMinimum 5 Charactres");
            }
            else
            {
                error4.Clear();
            }
        }

        private void set_name_Enter(object sender, EventArgs e)
        {
            if(set_name.Text =="Full Name")
            {
                set_name.Text = "";
                set_name.ForeColor = Color.Black;
            }
        }

        private void set_username_Enter(object sender, EventArgs e)
        {
            if (set_username.Text == "username")
            {
                set_username.Text = "";
                set_username.ForeColor = Color.Black;
            }
        }

        private void set_email_Enter(object sender, EventArgs e)
        {
            if (set_email.Text == "abc@gmail.com")
            {
                set_email.Text = "";
                set_email.ForeColor = Color.Black;
            }
        }

        private void set_password_Enter(object sender, EventArgs e)
        {
            if (set_password.Text == "Password")
            {
                set_password.Text = "";
                set_password.ForeColor = Color.Black;
            }
        }

        private void con_password_Enter(object sender, EventArgs e)
        {
            if (con_password.Text == "Password")
            {
                con_password.Text = "";
                con_password.ForeColor = Color.Black;
            }
        }

        private void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            gend = Gender.SelectedItem.ToString();
            Gender.ForeColor = Color.Black;
        }

        private void Gender_Leave(object sender, EventArgs e)
        {
            if(gend == "" || gend == "Gender")
            {
                Gender.Focus();
                error7.SetError(this.Gender, "Select your gender");
            }
            else
            {
                error7.Clear();
            }
        }

        private void Gender_Enter(object sender, EventArgs e)
        {
            Gender.Text = "";
            Gender.ForeColor= Color.Black;
        }

        private void set_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void con_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void set_name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
