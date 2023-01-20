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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSignup
{
    public partial class Reset_Password : Form
    {
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        // pattern is for checking the given mail format is valid or not
        string code;
        bool cliked = false;
        public static string to;
        int second = 0;
        public Reset_Password()
        {
            InitializeComponent();
            email.Text = ForgotPassword.gmail;
            email.ReadOnly = true;
            second = 29;
            //countdown.Start();
            resend_otp.Text = "";
            sec_txt.Text = "";

        }

        private void Send_Otp_Click(object sender, EventArgs e)
        {
            string from, pass, messagebody;
            if (email.Text != "" && Regex.IsMatch(email.Text, pattern) == true)
            {
                if (email.Text == ForgotPassword.gmail)
                {
                    try
                    {
                        Random rand = new Random();
                        code = rand.Next(999999).ToString();
                        MailMessage message = new MailMessage();
                        to = email.Text;
                        from = "city.transport.ltd.242@gmail.com";
                        pass = "CITYTRANSPORT";
                        messagebody = $"Your Reset Code is {code}";
                        message.To.Add(to);
                        message.From = new MailAddress(from);
                        message.Body = messagebody;
                        message.Subject = "Reset Password";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);
                        try
                        {
                            smtp.Send(message);
                            //MessageBox.Show("Code Successfully Send");
                            MessageBox.Show("We have send a code to your mail");
                            cliked = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Enter your valid mail");
                    }
                }
                else
                {
                    try
                    {
                        Random rand = new Random();
                        code = rand.Next(999999).ToString();
                        MailMessage message = new MailMessage();
                        to = email.Text;
                        from = "city.transport.ltd.242@gmail.com";
                        pass = "CITYTRANSPORT";
                        messagebody = $"Your Reset Code is {code}";
                        message.To.Add(to);
                        message.From = new MailAddress(from);
                        message.Body = messagebody;
                        message.Subject = "Reset Password";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);
                        try
                        {
                            smtp.Send(message);
                            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                            con.Open();
                            MySqlCommand cmd;
                            cmd = con.CreateCommand();
                            cmd.CommandText = "UPDATE user_info SET email=@Email WHERE email = @Nemail";
                            cmd.Parameters.AddWithValue("@Email", email.Text);
                            cmd.Parameters.AddWithValue("@Nemail", ForgotPassword.gmail);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            //MessageBox.Show("Code Successfully Send");
                            MessageBox.Show("We have send a code to your mail");
                            cliked = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Enter your valid mail");
                    }
                }
                resend();
            }
            else
            {
                MessageBox.Show("Enter your mail");
            }
        }

        private void resend()
        {
            resend_otp.Text = "Resend OTP in";
            sec_txt.Text = "30s";
            countdown.Start();
        }

        private void verify_btn_Click(object sender, EventArgs e)
        {
            if (cliked)
            {
                if (code == otp.Text)
                {
                    to = email.Text;
                    this.Hide();
                    new change_password().ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong Code!!");
                }
            }
            else
            {
                email.BackColor = Color.Red;
                MessageBox.Show("Enter your mail first");
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if (email.Text == "" || Regex.IsMatch(email.Text, pattern) == false)
            {
                email.Focus();
                error1.SetError(this.email, "Enter a valid email");
            }
            else
            {
                error1.Clear();
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ForgotPassword().ShowDialog();
            Close();
        }

        private void otp_Leave(object sender, EventArgs e)
        {
            if (otp.Text == "")
            {
                otp.Focus();
                error1.SetError(this.otp, "Enter verification code");
            }
            else
            {
                error1.Clear();
            }
        }

        private void countdown_Tick(object sender, EventArgs e)
        {
            sec_txt.Text = second--.ToString() + "s";
            if (second < 0)
            {
                countdown.Stop();
                sec_txt.Text = "";
                resend_otp.Text = "Resend OTP?";
            }
        }

        private void resend_otp_Click(object sender, EventArgs e)
        {
            second = 29;
            string from, pass, messagebody;
            Random rand = new Random();
            code = rand.Next(999999).ToString();
            MailMessage message = new MailMessage();
            to = email.Text;
            from = "city.transport.ltd.242@gmail.com";
            pass = "CITYTRANSPORT";
            messagebody = $"Your Reset Code is {code}";
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Reset Password";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                //MessageBox.Show("Code Successfully Send");
                MessageBox.Show("We have send a code to your mail");
                cliked = true;
                resend();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset_Password_Load(object sender, EventArgs e)
        {

        }
    }
}
