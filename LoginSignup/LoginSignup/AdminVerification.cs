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
    public partial class AdminVerification : Form
    {
        int second = 0;
        public AdminVerification()
        {
            InitializeComponent();
            second = 29;
            resend();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminLogin().ShowDialog();
            this.Close();
        }

        private void verify_btn_Click(object sender, EventArgs e)
        {
            if (admin_code.Text == AdminLogin.code)
            {
                this.Hide();
                new AdminLoading().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }

        private void resend_otp_Click(object sender, EventArgs e)
        {
            if (resend_otp.Text == "Resend OTP?")
            {
                second = 29;
                string from, pass, messagebody;
                try
                {
                    Random rand = new Random();
                    AdminLogin.code = rand.Next(999999).ToString();
                    MailMessage message = new MailMessage();
                    //to = sdr["email"].ToString();
                    from = "city.transport.ltd.242@gmail.com";
                    pass = "CITYTRANSPORT";
                    messagebody = $"Admin verification Code is {AdminLogin.code}";
                    message.To.Add(AdminLogin.to);
                    message.From = new MailAddress(from);
                    message.Body = messagebody;
                    message.Subject = "Admin Verification";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.Send(message);
                    MessageBox.Show("We have send a varification code to your mail");
                    resend();
                }
                catch
                {
                    MessageBox.Show("Something is went wrong!\nTry again later");
                }
            }
        }

        private void resend()
        {
            resend_otp.Text = "Resend OTP in";
            sec_txt.Text = "30s";
            countdown.Start();
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
    }
}
