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
    public partial class AddRoute : Form
    {
        string pk;
        static int code;
        public AddRoute()
        {
            InitializeComponent();
            if(code == 1)
            {
                label1.Text = "Edit Route";
                from.Text = AdminPanel.v1;
                to.Text = AdminPanel.v2;
                fare.Text = AdminPanel.v3;
                time.Text = AdminPanel.v4;
                buscode.Text = AdminPanel.v5;
                routeno.Text = AdminPanel.v6;
                pk = AdminPanel.v6;
                from.ReadOnly = false;
                to.ReadOnly = false;
                fare.ReadOnly = false;
                time.ReadOnly = false;
                buscode.ReadOnly = false;
                routeno.ReadOnly = true;
            }
            else if(code ==2)
            {
                label1.Text = "Edit Route";
                from.Text = SuperviserPanel.v1;
                to.Text = SuperviserPanel.v2;
                fare.Text = SuperviserPanel.v3;
                time.Text = SuperviserPanel.v4;
                buscode.Text = SuperviserPanel.v5;
                routeno.Text = SuperviserPanel.v6;
                pk = SuperviserPanel.v6;
                from.ReadOnly = true;
                to.ReadOnly = true;
                fare.ReadOnly = true;
                time.ReadOnly = false;
                buscode.ReadOnly = true;
                routeno.ReadOnly = true;
            }
            else
            {
                label1.Text = "Add Route";
                from.ReadOnly = false;
                to.ReadOnly = false;
                fare.ReadOnly = false;
                time.ReadOnly = false;
                buscode.ReadOnly = false;
                routeno.ReadOnly = false;
            }
        }

        private void clr_btn_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        public static void Check(int a)
        {
            code = a;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (code == 0)
            {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM route WHERE route_no = @BSBS";
                cmd.Parameters.AddWithValue("@BSBS", routeno.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Route number already exists\n");
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    try
                    {
                        cmd.CommandText = "INSERT INTO route(route_no,from_where,to_where,fare,time,bus_code) VALUES (@rn,@fw,@tw,@f,@t,@bc)";
                        cmd.Parameters.AddWithValue("@rn", routeno.Text);
                        cmd.Parameters.AddWithValue("@fw", from.Text);
                        cmd.Parameters.AddWithValue("@tw", to.Text);
                        cmd.Parameters.AddWithValue("@f", fare.Text);
                        cmd.Parameters.AddWithValue("@t", time.Text);
                        cmd.Parameters.AddWithValue("@bc", buscode.Text);
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
            else if(code==1)
            {
                if (from.Text == AdminPanel.v1 && to.Text == AdminPanel.v2 && fare.Text == AdminPanel.v3 && time.Text == AdminPanel.v4
                    && buscode.Text == AdminPanel.v5)
                {
                    MessageBox.Show("Change something to update the record");
                }
                else
                {
                    /// update option kaj korate hoile ekta route_no naam a column add korte hobe
                    /// 

                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    try
                    {
                        cmd.CommandText = "UPDATE route SET from_where=@fw,to_where=@tw,fare=@f,time=@t,bus_code=@bc WHERE route_no = @rn";
                        cmd.Parameters.AddWithValue("@fw", from.Text);
                        cmd.Parameters.AddWithValue("@tw", to.Text);
                        cmd.Parameters.AddWithValue("@f", fare.Text);
                        cmd.Parameters.AddWithValue("@t", time.Text);
                        cmd.Parameters.AddWithValue("@bc", buscode.Text);
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
            else if(code==2)
            {
                if (time.Text == SuperviserPanel.v4)
                {
                    MessageBox.Show("Change time to update the record");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    try
                    {
                        cmd.CommandText = "UPDATE route SET time=@t WHERE route_no = @rn";
                        cmd.Parameters.AddWithValue("@t", time.Text);
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
        }
        private void ResetData()
        {
            if (code == 0)
            {
                routeno.Text = "";
                from.Text = "";
                to.Text = "";
                fare.Text = "";
                time.Text = "";
                buscode.Text = "";
            }
            else if(code ==1)
            {
                from.Text = "";
                to.Text = "";
                fare.Text = "";
                time.Text = "";
                buscode.Text = "";
            }
            else
            {
                time.Text = "";
            }
        }
    }
}
