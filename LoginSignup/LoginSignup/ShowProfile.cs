using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSignup
{
    public partial class ShowProfile : Form
    {
        Bitmap bmp;
        string gen="";
        public static string v1, v2, v3, v4, v5, v6;
        public ShowProfile()
        {
            InitializeComponent();
        }

        private void ShowProfile_Load(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void GetInfo()
        {
            if (MainMenu.code == 0)
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM user_info WHERE username = @UserName";
                cmd.Parameters.AddWithValue("@UserName", Login.uname);
                MySqlDataReader sdr = cmd.ExecuteReader();
                try
                {
                    if (sdr.Read())
                    {
                        name.Text = sdr["Name"].ToString();
                        gender.Text = sdr["gender"].ToString();
                        username.Text = sdr["username"].ToString();
                        gmail.Text = sdr["email"].ToString();
                    }
                    gen = gender.Text;
                    try
                    {
                        if (gen == "Male")
                        {
                            bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\male.png");
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox2.Image = bmp;
                        }
                        else
                        {
                            bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\female.png");
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox2.Image = bmp;
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("File Not Found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error\n" + ex);
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
                try
                {
                    if (sdr.Read())
                    {
                        name.Text = sdr["Name"].ToString();
                        gender.Text = sdr["gender"].ToString();
                        username.Text = sdr["username"].ToString();
                        gmail.Text = sdr["email"].ToString();
                    }
                    gen = gender.Text;
                    try
                    {
                        if (gen == "Male")
                        {
                            bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\SDP project\LoginSignup\LoginSignup\Resources\male.png");
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox2.Image = bmp;
                        }
                        else
                        {
                            bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\SDP project\LoginSignup\LoginSignup\Resources\female.png");
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox2.Image = bmp;
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("File Not Found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error\n" + ex);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            //new Dashboard().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ViewTicket().ShowDialog();
            this.Hide();
            this.Close();
        }
    }
}
