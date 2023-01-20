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
    public partial class AdminPanel : Form
    {
        public static string v1, v2, v3, v4, v5,v6;
        bool adminbtn = false, userbtn = false, busbtn = false;
        bool driverbtn = false, supervisorbtn = false, routebtn = false;
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        public AdminPanel()
        {
            InitializeComponent();
            ButtonCreate();
            btn.Visible = false;
            btn2.Visible = false;
            new_btn.Visible = false;
        }

        public void ShowResult(string txt)
        {
            edit.Text = txt;
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            MySqlDataReader sdr;
            //DataTable dt = new DataTable();
            if (txt == "Admin Info")
            {
                cmd.CommandText = "SELECT * FROM admin_info";
                sdr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);
            }
            else if(txt == "User Info")
            {
                cmd.CommandText = "SELECT * FROM user_info";
                sdr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);
            }
            else if(txt=="Bus Info")
            {
                cmd.CommandText = "SELECT * FROM bus_info";
                sdr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);
            }
            else if (txt == "Driver Info")
            {
                cmd.CommandText = "SELECT * FROM driver_info";
                sdr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);
            }
            else if (txt == "Supervisor Info")
            {
                cmd.CommandText = "SELECT * FROM supervisor_info";
                sdr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);
            }
            else
            {
                cmd.CommandText = "SELECT * FROM route";
                sdr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(sdr);
            }
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            dataGridView.DataSource = dt;
        }
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            //ButtonCreate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void new_btn_Click_1(object sender, EventArgs e)
        {
            if (adminbtn)
            {
                AddAdmin.Check(0);
                new AddAdmin().ShowDialog();
                ShowResult("Admin Info");
            }
            else if (busbtn)
            {
                AddBus.Check(0);
                new AddBus().ShowDialog();
                ShowResult("Bus Info");
            }
            else if (driverbtn)
            {
                AddDriver.Check(0);
                new AddDriver().ShowDialog();
                ShowResult("Driver Info");
            }
            else if (supervisorbtn)
            {
                AddSuperviser.Check(0);
                new AddSuperviser().ShowDialog();
                ShowResult("Supervisor Info");
            }
            else if(routebtn)
            {
                AddRoute.Check(0);
                new AddRoute().ShowDialog();
                ShowResult("Route");
            }
            
        }

        private void hm_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            bus_gif.Visible = true;
            new_btn.Visible = false;
            dataGridView.Visible = false;
            home.Text = "HOME";
            edit.Text = "";
            dataGridView.DataSource = null;
            this.Refresh();
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

            btn2.Text = "Delete";
            btn2.Name = "";
            btn2.DefaultCellStyle.BackColor = Color.IndianRed;
            btn2.DefaultCellStyle.ForeColor = Color.White;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btn2);
        }

        private void bus_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            dataGridView.Visible = true;
            bus_gif.Visible = false;
            new_btn.Visible = true;
            adminbtn = false; userbtn = false; busbtn = true;
            driverbtn = false; supervisorbtn = false; routebtn = false;
            edit.Text = "Bus Info";
            home.Text = "";
            ShowResult("Bus Info");
            btn.Visible = true;
            btn2.Visible = true;
        }

        private void driver_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            dataGridView.Visible = true;
            bus_gif.Visible = false;
            new_btn.Visible = true;
            adminbtn = false; userbtn = false; busbtn = false;
            driverbtn = true; supervisorbtn = false; routebtn = false;
            edit.Text = "Driver Info";
            home.Text = "";
            ShowResult("Driver Info");
            btn.Visible = true;
            btn2.Visible = true;
        }

        private void super_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            dataGridView.Visible = true;
            bus_gif.Visible = false;
            new_btn.Visible = true;
            adminbtn = false; userbtn = false; busbtn = false;
            driverbtn = false; supervisorbtn = true; routebtn = false;
            edit.Text = "Supervisor Info";
            home.Text = "";
            ShowResult("Supervisor Info");
            btn.Visible = true;
            btn2.Visible = true;
        }

        private void route_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            dataGridView.Visible = true;
            bus_gif.Visible = false;
            new_btn.Visible = true;
            adminbtn = false; userbtn = false; busbtn = false;
            driverbtn = false; supervisorbtn = false; routebtn = true;
            ShowResult("Route Info");
            btn.Visible = true;
            btn2.Visible = true;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string key;// = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure want to delete this record ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (adminbtn)
                    {
                        key = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                        cmd.CommandText = "DELETE FROM admin_info WHERE username = @UserName";
                        cmd.Parameters.AddWithValue("@UserName", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted From Admin Table");
                        ShowResult("Admin Info");
                    }
                    else if(userbtn)
                    {
                        key = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                        cmd.CommandText = "DELETE FROM user_info WHERE username = @UserName";
                        cmd.Parameters.AddWithValue("@UserName", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted From User Table");
                        ShowResult("User Info");
                    }
                    else if(busbtn)
                    {
                        key = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                        cmd.CommandText = "DELETE FROM bus_info WHERE bus_code = @BusCode";
                        cmd.Parameters.AddWithValue("@BusCode", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted From Bus Table");
                        ShowResult("Bus Info");
                    }
                    else if(driverbtn)
                    {
                        key = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                        cmd.CommandText = "DELETE FROM driver_info WHERE driver_id = @DID";
                        cmd.Parameters.AddWithValue("@DID", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted From Driver Table");
                        ShowResult("Driver Info");
                    }
                    else if(supervisorbtn)
                    {
                        key = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                        cmd.CommandText = "DELETE FROM supervisor_info WHERE suervisor_id = @SID";
                        cmd.Parameters.AddWithValue("@SID", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted From Suervisor Table");
                        ShowResult("Suervisor Info");
                    }
                    else
                    {
                        key = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
                        cmd.CommandText = "DELETE FROM route WHERE route_no = @rn";
                        cmd.Parameters.AddWithValue("@rn", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted From Route Table");
                        ShowResult("Route");
                    }
                }
            }
            else if(e.ColumnIndex == 0)
            {
                if (adminbtn)
                {
                    v1 = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    v2 = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                    v3 = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    v4 = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    v5 = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                    AddAdmin.Check(1);
                    new AddAdmin().ShowDialog();
                    ShowResult("Admin Info");
                }
                else if (busbtn)
                {
                    v1 = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    v2 = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                    v3 = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    v4 = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    AddBus.Check(1);
                    new AddBus().ShowDialog();
                    ShowResult("Bus Info");
                }
                else if (driverbtn)
                {
                    v1 = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    v2 = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                    v3 = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    v4 = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    AddDriver.Check(1);
                    new AddDriver().ShowDialog();
                    ShowResult("Driver Info");
                }
                else if (supervisorbtn)
                {
                    v1 = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    v2 = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                    v3 = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    v4 = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    v5 = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                    AddSuperviser.Check(1);
                    new AddSuperviser().ShowDialog();
                    ShowResult("Supervisor Info");
                }
                else
                {
                    v1 = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    v2 = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                    v3 = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    v4 = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    v5 = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
                    v6 = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
                    AddRoute.Check(1);
                    new AddRoute().ShowDialog();
                    ShowResult("Route");
                }
            }
            con.Close();
        }

        private void admn_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            dataGridView.Visible = true;
            bus_gif.Visible = false;
            new_btn.Visible = true;
            adminbtn = true; userbtn = false; busbtn = false;
            driverbtn = false; supervisorbtn = false; routebtn = false;
            edit.Text = "Admin Info";
            home.Text = "";
            ShowResult("Admin Info");
            btn.Visible = true;
            btn2.Visible = true;
        }

        private void user_btn_Click(object sender, EventArgs e)
        {
            search_txt.Text = "";
            dataGridView.Visible = true;
            bus_gif.Visible = false;
            new_btn.Visible = false;
            adminbtn = false; userbtn = true; busbtn = false;
            driverbtn = false; supervisorbtn = false; routebtn = false;
            edit.Text = "User Info";
            home.Text = "";
            ShowResult("User Info");
            btn.Visible = false;
            btn2.Visible = true;
        }
        
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (edit.Text == "Admin Info")
            {
                if (e.ColumnIndex == 4 && e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
                if (e.ColumnIndex == 2 && e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
            else if(edit.Text == "User Info")
            {
                if (e.ColumnIndex == 4 && e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
            else if (edit.Text == "Supervisor Info")
            {
                if (e.ColumnIndex == 6 && e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        private void search_txt_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(AppSettings.Connection());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            if (adminbtn)
            {
                
                cmd.CommandText = "SELECT * FROM admin_info WHERE Name LIKE '%"+search_txt.Text+ "%' OR username LIKE '%" + search_txt.Text + "%'";
            }
            else if(userbtn)
            {
                cmd.CommandText = "SELECT * FROM user_info WHERE name LIKE '%" + search_txt.Text + "%' OR username LIKE '%" + search_txt.Text + "%'";
            }
            else if(busbtn)
            {
                cmd.CommandText = "SELECT * FROM bus_info WHERE bus_code LIKE '%" + search_txt.Text + "%'";
            }
            else if(driverbtn)
            {
                cmd.CommandText = "SELECT * FROM driver_info WHERE driver_id LIKE '%" + search_txt.Text + "%' OR name LIKE '%" + search_txt.Text + "%'";
            }
            else if(supervisorbtn)
            {
                cmd.CommandText = "SELECT * FROM supervisor_info WHERE superviser_id LIKE '%" + search_txt.Text + "%' OR name LIKE '%" + search_txt.Text + "%'";
            }
            else if(routebtn)//route
            {
                cmd.CommandText = "SELECT * FROM route WHERE from_where LIKE '%" + search_txt.Text + "%' OR to_where LIKE '%" + search_txt.Text + "%' OR route_no LIKE '%" + search_txt.Text + "%'";
            }
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            dataGridView.DataSource = dt;
        }
    }
}
