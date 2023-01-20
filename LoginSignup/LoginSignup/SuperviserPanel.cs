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
    public partial class SuperviserPanel : Form
    {
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        bool busbtn=false,routebtn=false,ticketbtn=false;
        public static string v1, v2, v3, v4, v5, v6;
        string busco;
        public SuperviserPanel()
        {
            InitializeComponent();
            ButtonCreate();
            btn.Visible = false;
            edittxt.Text = "";
        }

        string dd="";
        private void ShowResult(string txt)
        {
            //string d = "   " + DateTime.UtcNow.ToString("MM-dd-yyyy");
            //MessageBox.Show(d + "");
            edittxt.Text = txt;
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            MySqlDataReader sdr;
            if (txt == "Bus Info")
            {
                cmd.CommandText = "SELECT * FROM bus_info WHERE supervisor_id = @SID";
                cmd.Parameters.AddWithValue("@SID",SupervisorLogin.superid);
            }
            else if (txt == "Route")
            {
                cmd.CommandText = "SELECT * FROM route WHERE bus_code = @BUSCO";
                cmd.Parameters.AddWithValue("@BUSCO", busco);
            }
            else if (txt == "Ticket Info")
            {
                cmd.CommandText = "SELECT * FROM ticket_info WHERE date = @DATE";
                cmd.Parameters.AddWithValue("@DATE",dd);
            }
            sdr=cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            dataGridView.DataSource = dt;
        }

        private void SuperviserPanel_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = dateTimePicker1.Value.AddDays(5);
            dd = dateTimePicker1.Text;
            dateTimePicker1.Visible = false;
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            MySqlDataReader sdr;
            cmd.CommandText = "SELECT bus_code FROM bus_info WHERE supervisor_id = @SID";
            cmd.Parameters.AddWithValue("@SID", SupervisorLogin.superid);
            sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                busco = sdr["bus_code"].ToString();
                con.Close();
            }
            search_txt.Text = "";
            busbtn = true; routebtn = false; ticketbtn = false;
            btn.Visible = true;
            ShowResult("Bus Info");
        }

        public void ButtonCreate()
        {
            btn.Text = "Edit";
            btn.Name = "";
            btn.DefaultCellStyle.BackColor = Color.MediumPurple;
            btn.DefaultCellStyle.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btn);
            
        }

        private void bus_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            busbtn = true; routebtn = false; ticketbtn = false;
            btn.Visible = true;
            ShowResult("Bus Info");
        }

        private void search_txt_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            if(busbtn)
            {
                cmd.CommandText = "SELECT * FROM bus_info WHERE bus_code LIKE '%" + search_txt.Text + "%'";
            }
            else if(routebtn)
            {
                cmd.CommandText = "SELECT * FROM route WHERE from_where LIKE '%" + search_txt.Text + "%' OR to_where LIKE '%" + search_txt.Text + "%' OR route_no LIKE '%" + search_txt.Text + "%'";
            }
            else if(ticketbtn)
            {
                cmd.CommandText = "SELECT * FROM ticket_info WHERE bus_code LIKE '%" + search_txt.Text + "%'";
            }
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            dataGridView.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                if(busbtn)
                {
                    v1 = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                    v2 = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    v3 = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                    v4 = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    AddBus.Check(2);
                    new AddBus().ShowDialog();
                    ShowResult("Bus Info");
                }
                else if(routebtn)
                {
                    v1 = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                    v2 = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    v3 = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                    v4 = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    v5 = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    v6 = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                    AddRoute.Check(2);
                    new AddRoute().ShowDialog();
                    ShowResult("Route");
                }
            }
        }

        private void route_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            busbtn = false; routebtn = true; ticketbtn = false;
            btn.Visible = true;
            ShowResult("Route");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            busbtn = false; routebtn = false; ticketbtn = true;
            btn.Visible = false;
            ShowResult("Ticket Info");
        }
    }
}
