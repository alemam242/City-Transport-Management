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
    public partial class MainMenu : Form
    {
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        bool hide1,hide2,hide3,hide4,hide5,hide6,hide7;
        public static int code,avlbl_sit,tk;
        public static string frm, where, busco, tm, dt;
        Bitmap bmp;
        bool a = true;
        bool createbutton = true;
        string fw, tw;
        public MainMenu()
        {
            InitializeComponent();
            if(createbutton)
            {
                CreateButton();
            }
            hide1 = true;
            sdpnl.Width = 0;
            hide2 = true;
            setting_pnl.Height = 0;
            hide3 = true;
            general_pnl.Height = 40;
            hide4 = true;
            security_pnl.Height = 40;
            hide5 = true;
            manage_pnl.Height = 40;
            hide6 = true;
            help_pnl.Height = 40;
            hide7 = true;
            view_pnl.Height = 25;
        }

        public void CreateButton()
        {
            btn.Text = "Buy Ticket";
            btn.Name = "";
            btn.DefaultCellStyle.BackColor = Color.DarkCyan;
            btn.DefaultCellStyle.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btn);
            createbutton = false;
        }
        public static void Checking(int i)
        {
            if (i == 0)
            {
                code = 0;
            }
            else
            {
                code = 1;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(hide1)
            {
                sdpnl.Width = sdpnl.Width + 20;
                if(sdpnl.Width>=200)
                {
                    timer1.Stop();
                    hide1=false;
                    this.Refresh();
                }
            }
            else
            {
                sdpnl.Width = sdpnl.Width - 20;
                if(sdpnl.Width <= 0)
                {
                    timer1.Stop();
                    hide1 = true;
                    this.Refresh();
                }
            }
        }

        private void general_btn_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void security_btn_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (hide4)
            {
                setting_pnl.Height = setting_pnl.Height + 20;
                security_pnl.Height = security_pnl.Height + 20;
                if (security_pnl.Height >= 100)
                {
                    timer4.Stop();
                    hide4 = false;
                    this.Refresh();
                }
            }
            else
            {
                setting_pnl.Height = setting_pnl.Height - 20;
                security_pnl.Height = security_pnl.Height - 20;
                if (security_pnl.Height <= 50)
                {
                    timer4.Stop();
                    hide4 = true;
                    this.Refresh();
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (hide5)
            {
                setting_pnl.Height = setting_pnl.Height + 20;
                manage_pnl.Height = manage_pnl.Height + 20;
                if (manage_pnl.Height >= 100)
                {
                    timer5.Stop();
                    hide5 = false;
                    this.Refresh();
                }
            }
            else
            {
                setting_pnl.Height = setting_pnl.Height - 20;
                manage_pnl.Height = manage_pnl.Height - 20;
                if (manage_pnl.Height <= 50)
                {
                    timer5.Stop();
                    hide5 = true;
                    this.Refresh();
                }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (hide6)
            {
                help_pnl.Height = help_pnl.Height + 20;
                if (help_pnl.Height >= 100)
                {
                    timer6.Stop();
                    hide6 = false;
                    this.Refresh();
                }
            }
            else
            {
                help_pnl.Height = help_pnl.Height - 20;
                if (help_pnl.Height <= 50)
                {
                    timer6.Stop();
                    hide6 = true;
                    this.Refresh();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new AboutUs().ShowDialog();
        }

        //private void AboutUs()
        //{
        //    MessageBox.Show("Developer\nName: Md. Al Emam\nStudy: B.Sc in CSE\nUniversity: BUBT" +
        //        "\n\nName: Anupam Kumar\nStudy: B.Sc in CSE\nUniversity: BUBT" +
        //        "\n\nName: Farhan Israq\nStudy: B.Sc in CSE\nUniversity: BUBT");
        //}

        private void label2_Click(object sender, EventArgs e)
        {
            ContactUs();
        }

        private void ContactUs()
        {
            MessageBox.Show("Thank you for reaching us! We are always happy to hear from you" +
                "\nMail: city.transport.ltd.242@gmail.com");
        }

        private void changepassword_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, You want to change your password ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //this.Hide();
                new ChangePasswordFromProfile().ShowDialog();
            }
        }

        private void deleteacnt_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, You want to delete this account ?", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM user_info WHERE username = @Username";
                cmd.Parameters.AddWithValue("@UserName", Login.uname);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Deleted");
                this.Hide();
                new Login().ShowDialog();
            }
        }

        private void editprofile_btn_Click(object sender, EventArgs e)
        {
            new EditProfile().ShowDialog();
        }

        private void profile_btn_Click(object sender, EventArgs e)
        {
            new ShowProfile().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if(hide7)
            {
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\UI_DESIGN\down.png");
                    arrow.SizeMode = PictureBoxSizeMode.Zoom;
                    arrow.Image = bmp;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File Not Found");
                }
                view_pnl.Height = view_pnl.Height + 20;
                if(view_pnl.Height >=300)
                {
                    timer7.Stop();
                    hide7= false;
                    this.Refresh();
                }
            }
            else
            {
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\UI_DESIGN\up.png");
                    arrow.SizeMode = PictureBoxSizeMode.Zoom;
                    arrow.Image = bmp;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File Not Found");
                }
                view_pnl.Height = view_pnl.Height - 20;
                if (view_pnl.Height <=25)
                {
                    timer7.Stop();
                    hide7 = true;
                    this.Refresh();
                }
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = dateTimePicker1.Value.AddDays(4);
            if(hide7)
            {
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\UI_DESIGN\up.png");
                    arrow.SizeMode = PictureBoxSizeMode.Zoom;
                    arrow.Image = bmp;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File Not Found");
                }
            }
            else
            {
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\UI_DESIGN\down.png");
                    arrow.SizeMode = PictureBoxSizeMode.Zoom;
                    arrow.Image = bmp;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File Not Found");
                }
            }

            //UpdateDatabase();
        }

        /*private void UpdateDatabase()
        {
            MessageBox.Show("FROM Method");
            string date1 = dateTimePicker1.Text;

            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM ticket_info WHERE date = @DT";
            cmd.Parameters.AddWithValue("@DT", date1);
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                while (sdr.Read())
                {
                    string busc = sdr["bus_id"].ToString();
                    int avs = Convert.ToInt32(sdr["booked_sit"].ToString());
                    con.Close();
                    int res = BUS(busc);
                    int total = res - avs;
                    MessageBox.Show("Sit = " + res + "\ntotal = " + total);
                    if (res != 0)
                    {
                        con.Open();
                        cmd.CommandText = "UPDATE bus_info SET available_sit = @AVS WHERE bus_code = @BUSCO";
                        cmd.Parameters.AddWithValue("@AVS", total);
                        cmd.Parameters.AddWithValue("@BUSCO", busc);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while Updating\n\n" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Somthing wrong with available sit");
                    }
                }
            }
        }

        public int BUS(string a)
        {
            int sit = 0;
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM bus_info WHERE bus_code = @BUSc";
            cmd.Parameters.AddWithValue("@BUSc", a);
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                sit = Convert.ToInt32(sdr["available_sit"].ToString());
            }
            con.Close();
            return sit;
        }*/

        private void search_btn_Click(object sender, EventArgs e)
        {
            string bc;
            dataGridView.Refresh();
            
            if (frm_txt.Text == "" || frm_txt.Text =="---Terminal---")
            {
                frm_txt.Focus();
                error1.SetError(this.frm_txt, "Enter area name");
            }
            else if(to_txt.Text =="" || to_txt.Text =="--Destination--")
            {
                to_txt.Focus();
                error1.SetError(this.to_txt, "Enter Destination");
            }
            else
            {
                fw=frm_txt.Text;
                tw=to_txt.Text;
                ShowResult();
            }
        }

        private void ShowResult()
        {
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            if (hide7)
            {
                timer7.Start();

                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT route.from_where, route.to_where, route.fare, route.time,route.bus_code, bus_info.available_sit" +
                        " FROM route INNER JOIN bus_info ON route.bus_code = bus_info.bus_code WHERE from_where = @FW AND to_where = @TW";
                cmd.Parameters.AddWithValue("@FW", fw);
                cmd.Parameters.AddWithValue("@TW", tw);
                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                dataGridView.DataSource = dt;
            }
            else
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT route.from_where, route.to_where, route.fare, route.time,route.bus_code, bus_info.available_sit" +
                        " FROM route INNER JOIN bus_info ON route.bus_code = bus_info.bus_code WHERE from_where = @FW AND to_where = @TW";

                cmd.Parameters.AddWithValue("@FW", fw);
                cmd.Parameters.AddWithValue("@TW", tw);
                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                dataGridView.DataSource = dt;
            }
            con.Close();
            //if (createbutton)
            //{
            //    //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //    btn.Text = "Buy Ticket";
            //    btn.Name = "";
            //    btn.DefaultCellStyle.BackColor = Color.DarkCyan;
            //    btn.DefaultCellStyle.ForeColor = Color.White;
            //    btn.FlatStyle = FlatStyle.Flat;
            //    btn.UseColumnTextForButtonValue = true;
            //    dataGridView.Columns.Add(btn);
            //    createbutton = false;
            //}
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void arrow_Click(object sender, EventArgs e)
        {
            if(hide7)
            {
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\UI_DESIGN\down.png");
                    arrow.SizeMode = PictureBoxSizeMode.Zoom;
                    arrow.Image = bmp;
                    timer7.Start();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File Not Found");
                }
            }
            else
            {
                try
                {
                    bmp = (Bitmap)Bitmap.FromFile(@"C:\Users\aryan\Desktop\UI_DESIGN\up.png");
                    arrow.SizeMode = PictureBoxSizeMode.Zoom;
                    arrow.Image = bmp;
                    timer7.Start();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File Not Found");
                }
            }
        }

        private void frm_txt_Enter(object sender, EventArgs e)
        {
            if (frm_txt.Text == "---Terminal---")
            {
                frm_txt.Text = "";
                frm_txt.ForeColor = Color.Black;
            }
        }

        private void frm_txt_Leave(object sender, EventArgs e)
        {
            if (frm_txt.Text == "" || frm_txt.Text == "---Terminal---")
            {
                frm_txt.Focus();
                error1.SetError(this.frm_txt, "Enter area name");
                frm_txt.Text = "---Terminal---";
                frm_txt.ForeColor = Color.Silver;
            }
            else
            {
                error1.Clear();
            }
        }

        private void to_txt_Leave(object sender, EventArgs e)
        {
            if (to_txt.Text == "" || to_txt.Text == "--Destination--")
            {
                to_txt.Focus();
                error1.SetError(this.to_txt, "Enter area name");
            }
            else
            {
                error1.Clear();
            }
        }

        private void to_txt_Enter(object sender, EventArgs e)
        {
            if (to_txt.Text == "--Destination--")
            {
                to_txt.Text = "";
                to_txt.ForeColor = Color.Black;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                frm = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                where = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                tk = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[3].Value.ToString());
                tm = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                busco = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                avlbl_sit = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[6].Value.ToString());
                dt = dateTimePicker1.Text.ToString();
                if (avlbl_sit > 0)
                {
                    new ConfirmTicket().ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry!!!\nSit not available");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void hlp_btn_Click(object sender, EventArgs e)
        {
            timer6.Start();
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
            timer5.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(hide3)
            {
                setting_pnl.Height = setting_pnl.Height + 20;
                general_pnl.Height = general_pnl.Height + 20;
                if(general_pnl.Height >= 100)
                {
                    timer3.Stop();
                    hide3= false;
                    this.Refresh();
                }
            }
            else
            {
                setting_pnl.Height = setting_pnl.Height - 20;
                general_pnl.Height = general_pnl.Height - 20;
                if(general_pnl.Height <= 50)
                {
                    timer3.Stop();
                    hide3 = true;
                    this.Refresh();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (hide2)
            {
                setting_pnl.Height = setting_pnl.Height + 20;
                if (setting_pnl.Height >= 125)
                {
                    timer2.Stop();
                    hide2 = false;
                    this.Refresh();
                }
            }
            else
            {
                setting_pnl.Height = setting_pnl.Height - 20;
                if (setting_pnl.Height <= 0)
                {
                    timer2.Stop();
                    hide2 = true;
                    this.Refresh();
                }
            }
        }

        private void setting_btn_Click(object sender, EventArgs e)
        {
            if (hide3 == true && hide4 == true && hide5 == true)
            {
                timer2.Start();
            }
        }
    }
}
