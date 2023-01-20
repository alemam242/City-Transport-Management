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
    public partial class ViewTicket : Form
    {
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        string ticketcode,nm,frm,to,bi,bs,dt,tm,total,namee;
        public static int x=1;

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ViewTicket()
        {
            InitializeComponent();
            ButtonCreate();
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            MySqlDataReader sdr;
            if (x == 0)
            {
                cmd.CommandText = "SELECT name FROM user_info WHERE username = @UN";
                cmd.Parameters.AddWithValue("@UN", Login.uname);
            }
            else if(x == 1)
            {
                cmd.CommandText = "SELECT name FROM user_info WHERE username = @UN";
                cmd.Parameters.AddWithValue("@UN", SignupForm.uname);
            }
            sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                namee = sdr["name"].ToString();
                con.Close();
            }
            ShowResult();
        }
        
        public static void Check(int i)
        {
            x = i;
        }
        private void ShowResult()
        {
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            MySqlDataReader sdr;
            cmd.CommandText = "SELECT * FROM ticket_info WHERE passenger_name = @NM";
            cmd.Parameters.AddWithValue("@NM", namee);
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            dataGridView.DataSource = dt;
        }

        public void ButtonCreate()
        {
            btn.Text = "Download";
            btn.Name = "";
            btn.DefaultCellStyle.BackColor = Color.MediumPurple;
            btn.DefaultCellStyle.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btn);

            btn2.Text = "Delete";
            btn2.Name = "";
            btn2.DefaultCellStyle.BackColor = Color.IndianRed;
            btn2.DefaultCellStyle.ForeColor = Color.White;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btn2);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                ticketcode = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                nm = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                frm = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                to = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                bi = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                bs = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
                dt = dataGridView.SelectedRows[0].Cells[8].Value.ToString();
                tm = dataGridView.SelectedRows[0].Cells[9].Value.ToString();
                total = dataGridView.SelectedRows[0].Cells[10].Value.ToString();
                PrintDialog pd = new PrintDialog();
                pd.Document = printDocument1;
                DialogResult result = pd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                    this.Hide();
                    this.Close();
                }
            }
            else if(e.ColumnIndex == 1)
            {
                string tc = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                if (MessageBox.Show("Are you sure want to delete ticket ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM ticket_info WHERE ticket_code = @TIC";
                    cmd.Parameters.AddWithValue("@TIC", tc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Deleted");
                    ShowResult();
                }
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("CITY TRANSORT", new Font("Monospaced", 24, FontStyle.Bold), Brushes.Black, new Point(260, 100));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 130));
            e.Graphics.DrawString("Ticket Code: " + ticketcode, new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 150));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 170));
            e.Graphics.DrawString("Issue Date: " + DateTime.UtcNow.ToString("dd-MM-yyyy"), new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 190));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 210));
            e.Graphics.DrawString("Passenger Name: " + nm, new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 230));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 250));
            e.Graphics.DrawString("From: " + frm, new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 270));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 290));
            e.Graphics.DrawString("To: " + to, new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 310));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 330));
            e.Graphics.DrawString("Journey Date:" + dt, new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 350));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 370));
            e.Graphics.DrawString("Departure Time: " + tm, new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 390));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 410));
            e.Graphics.DrawString("Person: " + bs, new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 430));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 450));
            e.Graphics.DrawString("Total Fare: " + total + " TK", new Font("Monospaced", 15, FontStyle.Bold), Brushes.Black, new Point(150, 470));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 490));
            e.Graphics.DrawString("Contact us:   : city.transport.ltd.242@gmail.com", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(150, 510));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 530));
            e.Graphics.DrawString("Thank You See You Again", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(255, 550));
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Monospaced", 15, FontStyle.Regular), Brushes.Black, new Point(120, 570));
        }
    }
}
