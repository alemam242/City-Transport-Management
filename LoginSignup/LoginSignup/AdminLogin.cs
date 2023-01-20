using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSignup
{
    public partial class AdminLogin : Form
    {
        public static string code, to;
        int count;
        public AdminLogin()
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
                admin_password.PasswordChar = '\0';
            }
            else
            {
                admin_password.PasswordChar = '*';
            }
        }

        private void admin_username_Enter(object sender, EventArgs e)
        {
            if (admin_username.Text == "username")
            {
                admin_username.Text = "";
                admin_username.ForeColor = Color.Black;
            }
        }

        private void admin_code_Enter(object sender, EventArgs e)
        {
            if (admin_code.Text == "Code")
            {
                admin_code.Text = "";
                admin_code.ForeColor = Color.Black;
            }
        }

        private void admin_password_Enter(object sender, EventArgs e)
        {
            if (admin_password.Text == "Password")
            {
                admin_password.Text = "";
                admin_password.ForeColor = Color.Black;
            }
        }

        private void admin_username_Leave(object sender, EventArgs e)
        {
            if (admin_username.Text == "")
            {
                admin_username.Text = "username";
                admin_username.ForeColor = Color.Silver;
            }
            else
            {
                count = 0;
                string str = admin_username.Text;
                char ch;
                int j = str.Length;
                for(int i = 0; i < j; i++)
                {
                    ch= str[i];
                    if(char.IsUpper(ch))
                    {
                        count++;
                    }
                }
            }
        }

        private void admin_code_Leave(object sender, EventArgs e)
        {
            if (admin_code.Text == "")
            {
                admin_code.Text = "Code";
                admin_code.ForeColor = Color.Silver;
            }
        }

        private void admin_password_Leave(object sender, EventArgs e)
        {
            if (admin_password.Text == "")
            {
                admin_password.Text = "Password";
                admin_password.ForeColor = Color.Silver;
            }
        }

        private void admin_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void admin_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (admin_username.Text == "" || admin_code.Text == "" || admin_password.Text == "")
            {
                MessageBox.Show("Fill al the box");
            }
            else if(count>0)
            {
                admin_username.Focus();
                error2.SetError(this.admin_username, "Ignore Uppercase");
            }
            else
            {
                error2.Clear();
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT email FROM admin_info WHERE code = @Code AND username = @UserName AND password = @Password";
                cmd.Parameters.AddWithValue("@Code", admin_code.Text);
                cmd.Parameters.AddWithValue("@UserName", admin_username.Text);
                cmd.Parameters.AddWithValue("@Password", admin_password.Text);
                MySqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    to = sdr["email"].ToString();
                    con.Close();
                    string from, pass, messagebody;
                    try
                    {
                            Random rand = new Random();
                            code = rand.Next(999999).ToString();
                            MailMessage message = new MailMessage();
                            //to = sdr["email"].ToString();
                            from = "city.transport.ltd.242@gmail.com";
                            pass = "CITYTRANSPORT";
                            messagebody = $"Admin verification Code is {code}";
                            message.To.Add(to);
                            message.From = new MailAddress(from);
                            message.Body = messagebody;
                            message.Subject = "Admin Verification";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Credentials = new NetworkCredential(from, pass);
                            smtp.Send(message);
                                //MessageBox.Show("Code Successfully Send");
                            MessageBox.Show("We have send a varification code to your mail");
                        this.Hide();
                        //new AdminPanel().ShowDialog();
                        new AdminVerification().ShowDialog();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Something is went wrong!\nTry again later");
                    }
                }
                else
                {
                    admin_username.Text = "";
                    admin_code.Text = "";
                    admin_password.Text = "";
                    MessageBox.Show("Invalid username or password!!");
                }
            }
        }
    }
}
