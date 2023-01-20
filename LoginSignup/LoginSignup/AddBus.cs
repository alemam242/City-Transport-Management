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
    public partial class AddBus : Form
    {
        static int code;
        string pk;
        public AddBus()
        {
            InitializeComponent();
            if(code == 0)
            {
                label1.Text = "Add Bus";
                driverid.ReadOnly = false;
                sid.ReadOnly = false;
                buscode.ReadOnly = false;
                asit.ReadOnly = false;
            }
            else if (code == 1)
            {
                label1.Text = "Edit Bus";
                buscode.Text = AdminPanel.v1;
                driverid.Text = AdminPanel.v2;
                sid.Text = AdminPanel.v3;
                asit.Text = AdminPanel.v4;
                pk = AdminPanel.v1;
                driverid.ReadOnly = false;
                sid.ReadOnly = false;
                buscode.ReadOnly = false;
                asit.ReadOnly = true;
            }
            else
            {
                label1.Text = "Edit Bus";
                buscode.Text = SuperviserPanel.v1;
                driverid.Text = SuperviserPanel.v2;
                sid.Text = SuperviserPanel.v3;
                asit.Text = SuperviserPanel.v4;
                pk = SuperviserPanel.v1;
                driverid.ReadOnly = true;
                sid.ReadOnly = true;
                buscode.ReadOnly = true;
                asit.ReadOnly = false;
            }
        }
        public static void Check(int a)
        {
            code = a;
        }

        private void clr_btn_Click(object sender, EventArgs e)
        {
            ResetData();
        }
        private void ResetData()
        {
            if (code == 0)
            {
                
                driverid.Text = "";
                sid.Text = "";
                asit.Text = "";
                buscode.Text = "";
            }
            else if (code == 1)
            {
                driverid.Text = "";
                sid.Text = "";
                buscode.Text = "";
            }
            else
            {
                asit.Text = "";
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (code == 0)
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM bus_info WHERE bus_code = @BSBS";
                cmd.Parameters.AddWithValue("@BSBS", buscode.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string s1 = dr["driver_id"].ToString();
                    string s2 = dr["supervisor_id"].ToString();
                    if (s1 == driverid.Text && s2 == sid.Text)
                    {
                        MessageBox.Show("This Bus code, driver id and supervisor id already exists\n");
                    }
                    else if (s1 == buscode.Text)
                    {
                        MessageBox.Show("This Bus code and driver id already exists\n");
                    }
                    else if (s2 == sid.Text)
                    {
                        MessageBox.Show("This Bus code and supervisor id already exists\n");
                    }
                    else
                    {
                        MessageBox.Show("Bus code already exists\n");
                    }
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    try
                    {
                        cmd.CommandText = "INSERT INTO bus_info(bus_code,driver_id,supervisor_id,available_sit) VALUES (@bc,@fw,@tw,@f)";
                        cmd.Parameters.AddWithValue("@bc", buscode.Text);
                        cmd.Parameters.AddWithValue("@fw", driverid.Text);
                        cmd.Parameters.AddWithValue("@tw", sid.Text);
                        cmd.Parameters.AddWithValue("@f", asit.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data Inserted");
                        ResetData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data cann't be Inserted\n" + ex);
                    }
                }

            }
            else if (code == 1)
            {
                if (buscode.Text == AdminPanel.v1 && driverid.Text == AdminPanel.v2 && sid.Text == AdminPanel.v3 && asit.Text == AdminPanel.v4)
                {
                    MessageBox.Show("Change something to update the record");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    try
                    {
                        cmd.CommandText = "UPDATE bus_info SET bus_code=@bc,driver_id=@fw,supervisor_id=@tw,available_sit=@f WHERE bus_code = @rn";
                        cmd.Parameters.AddWithValue("@bc", buscode.Text);
                        cmd.Parameters.AddWithValue("@fw", driverid.Text);
                        cmd.Parameters.AddWithValue("@tw", sid.Text);
                        cmd.Parameters.AddWithValue("@f", asit.Text);
                        cmd.Parameters.AddWithValue("@rn", pk);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data Update");
                        ResetData();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data cann't be Updated\n" + ex);
                    }
                }
            }
            else if (code == 2)
            {
                if (asit.Text == SuperviserPanel.v4)
                {
                    MessageBox.Show("Change value of available sit to update the record");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    int s = Convert.ToInt32(asit.Text);
                    try
                    {
                        if (s <= 40)
                        {
                            cmd.CommandText = "UPDATE bus_info SET available_sit=@t WHERE bus_code = @rn";
                            cmd.Parameters.AddWithValue("@t", s);
                            cmd.Parameters.AddWithValue("@rn", pk);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Record Updated");
                            ResetData();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Maximum 40 sit available in a bus");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data cann't be Updated\n" + ex);
                    }
                }
            }
        }
    }
}
