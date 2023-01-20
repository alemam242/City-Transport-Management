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
    public partial class ConfirmTicket : Form
    {
        string naam, nm, gm, gnd;
        int p = 1, total = 0;
        string ticketcode = "CT";
        int rn;
        public ConfirmTicket()
        {
            InitializeComponent();
            GetInfo();
            lbl1.Text = "TICKET BOOKING";
            txtname.Text = nm;
            txtname.ReadOnly = true;
            txtemail.ReadOnly = false;
            txtperson.ReadOnly = false;
            button1.Visible = true;
            download_btn.Visible = false;
            upbtn.Enabled = true;
            downbtn.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;

            txtemail.Text = gm;
            txtperson.Text = p.ToString();
            txtfrom.Text = MainMenu.frm;
            txtto.Text = MainMenu.where;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                gnd = "Male";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                gnd = "Femalle";
            }
        }

        private void upbtn_Click(object sender, EventArgs e)
        {
            p = p + 1;
            if (p < MainMenu.avlbl_sit)
            {
                if (p <= 4)
                {
                    txtperson.Text = p.ToString();
                }
                else
                {
                    p = p - 1;
                    MessageBox.Show("More than 4 sit cann't be selected");
                }
            }
            else
            {
                p = p - 1;
                MessageBox.Show("Only " + p + " Sit are available");
            }
        }

        private void downbtn_Click(object sender, EventArgs e)
        {
            p = p - 1;
            if (p <= 0)
            {
                p = p + 1;
                MessageBox.Show("Atleast 1 sit you have to book");
            }
            else
            {
                txtperson.Text = p.ToString();
            }
        }

        private void txtperson_Leave(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtperson.Text.ToString());
            if (x > 4)
            {
                MessageBox.Show("More than 4 sit cann't be selected");
                txtperson.Text = "1";

                p = 1;
            }
            else if (x <= 0)
            {
                MessageBox.Show("Atleast 1 sit you have to book");
                txtperson.Text = "1";

                p = 1;
            }
            else
            {
                p = x;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            int tmp = 0;
            total = p * MainMenu.tk;
            int sit = MainMenu.avlbl_sit - p;
            DateTime date1 = DateTime.Now;
            DateTime date2 = Convert.ToDateTime(MainMenu.dt);

            Random rand = new Random();
            rn = rand.Next(999999);
            tmp = rand.Next(999);
            if (rn % 2 == 0)
            {
                ticketcode = ticketcode + (rn + tmp).ToString();
            }
            else
            {
                ticketcode = ticketcode + (rn - tmp).ToString();
            }
            ticketcode = ticketcode + "AS";

            int res = date1.Date.CompareTo(date2);
            if (res == 0)
            {
                con.Open();
                cmd.CommandText = "UPDATE bus_info SET available_sit = @AS WHERE bus_code = @BC";
                cmd.Parameters.AddWithValue("@AS", sit);
                cmd.Parameters.AddWithValue("@BC", MainMenu.busco);
                try
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    try
                    {
                        con.Open();
                        cmd.CommandText = "SELECT * FROM ticket_info WHERE ticket_code = @TCode";
                        cmd.Parameters.AddWithValue("@TCode", ticketcode);
                        MySqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            ticketcode = "CT" + (rn - tmp).ToString() + "0AS";
                            con.Close();
                        }
                        else
                            con.Close();
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something wrong\n" + ex);
                }
            }
            try
            {
                con.Open();
                cmd.CommandText = "INSERT INTO ticket_info(ticket_code,passenger_name,from_where,to_where,bus_id,booked_sit,date,time,total_fare) VALUES (@TCO,@PN,@FW,@TW,@BI,@BS,@DT,@TM,@TF)";
                cmd.Parameters.AddWithValue("@TCO", ticketcode);
                cmd.Parameters.AddWithValue("@PN", nm);
                cmd.Parameters.AddWithValue("@FW", MainMenu.frm);
                cmd.Parameters.AddWithValue("@TW", MainMenu.where);
                cmd.Parameters.AddWithValue("@BI", MainMenu.busco);
                cmd.Parameters.AddWithValue("@BS", p);
                cmd.Parameters.AddWithValue("@DT", MainMenu.dt);
                cmd.Parameters.AddWithValue("@TM", MainMenu.tm);
                cmd.Parameters.AddWithValue("@TF", total);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Inserting into ticket info\n" + ex);
            }
            new TicketLoading().ShowDialog();
            lbl1.Text = "Download Ticket";
            txtname.ReadOnly = true;
            txtemail.ReadOnly = true;
            txtperson.ReadOnly = true;
            button1.Visible = false;
            download_btn.Visible = true;
            upbtn.Enabled = false;
            downbtn.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;

            //MessageBox.Show("Update Successfull");
        }

        private void t1_Tick(object sender, EventArgs e)
        {
            //t1.Stop();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("CITY TRANSORT", new Font("Monospaced", 24, FontStyle.Bold), Brushes.Black, new Point(250, 100));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 130));
            e.Graphics.DrawString("Ticket Code   : " + ticketcode, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 160));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 190));
            e.Graphics.DrawString("Issue Date    :" + DateTime.UtcNow.ToString("dd-MM-yyyy"), new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 220));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 250));
            e.Graphics.DrawString("Passenger Name: "+nm, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 280));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 310));
            e.Graphics.DrawString("Email         : " + gm, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 340));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 370));
            e.Graphics.DrawString("Gender        : " + gnd, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 400));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 430));
            e.Graphics.DrawString("Journey Date  :" + MainMenu.dt, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 460));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 490));
            e.Graphics.DrawString("From          : " + MainMenu.frm, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 520));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 550));
            e.Graphics.DrawString("To            : " + MainMenu.where, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 580));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 610));
            e.Graphics.DrawString("Departure Time: " + MainMenu.tm, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 640));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 670));
            e.Graphics.DrawString("Person        : " + p, new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 700));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 730));
            e.Graphics.DrawString("Total Fare    : " + total + " TK", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 760));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 790));
            e.Graphics.DrawString("Contact us:   : city.transport.ltd.242@gmail.com", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 820));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 850));
        }

        private void download_btn_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;
            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
                this.Close();
            }
        }

        private void GetInfo()
        {
            if (MainMenu.code == 0)
            {
                naam = Login.uname;
            }
            else
            {
                naam = SignupForm.uname;
            }
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from user_info WHERE username = @UserName";
            cmd.Parameters.AddWithValue("@UserName", naam);
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                nm = sdr["name"].ToString();
                gnd = sdr["gender"].ToString();
                gm = sdr["email"].ToString();
                con.Close();
            }
            if (gnd == "Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public int BUS(string a)
        //{
        //    int sit=0;
        //    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
        //    con.Open();
        //    MySqlCommand cmd;
        //    cmd = con.CreateCommand();
        //    cmd.CommandText = "SELECT * FROM bus_info WHERE bus_code = @BUSc";
        //    cmd.Parameters.AddWithValue("@BUSc", a);
        //    MySqlDataReader sdr = cmd.ExecuteReader();
        //    if(sdr.Read())
        //    {
        //        sit = Convert.ToInt32(sdr["available_sit"].ToString());
        //    }
        //    con.Close();
        //    return sit;
        //}
        
        private void ConfirmTicket_Load(object sender, EventArgs e)
        {
            //DateTime datte1 = DateTime.Now;
            //string d = datte1.ToString();
            //MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            //con.Open();
            //MySqlCommand cmd;
            //cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT * FROM ticket_info WHERE date = @DT";
            //cmd.Parameters.AddWithValue("@DT", d);
            //MySqlDataReader sdr = cmd.ExecuteReader();
            //if(sdr.Read())
            //{
            //    while(sdr.Read())
            //    {
            //        string busc = sdr["bus_code"].ToString();
            //        int avs = Convert.ToInt32(sdr["person"].ToString());
            //        con.Close();
            //        int res = BUS(busc);
            //        int total = res - avs;
            //        if (res != 0)
            //        {
            //            con.Open();
            //            cmd.CommandText = "UPDATE bus_info SET available_sit = @AVS WHERE bus_code = @BUSCO";
            //            cmd.Parameters.AddWithValue("@AVS", total);
            //            cmd.Parameters.AddWithValue("@BUSCO", busc);
            //            try
            //            {
            //                cmd.ExecuteNonQuery();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Error while Updating\n\n" + ex);
            //            }
            //        }
            //    }
            //}

        }
    }
}
