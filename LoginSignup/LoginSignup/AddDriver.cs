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
    public partial class AddDriver : Form
    {
        static int code;
        string pk;
        public AddDriver()
        {
            InitializeComponent();
            if (code == 0)
            {
                label1.Text = "Add Driver";
            }
            else if (code == 1)
            {
                label1.Text = "Edit Driver";
                driverid.Text = AdminPanel.v1;
                name.Text = AdminPanel.v2;
                driving.Text = AdminPanel.v3;
                phone.Text = AdminPanel.v4;
                pk = AdminPanel.v1;
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
            driverid.Text = "";
            name.Text = "";
            driving.Text = "";
            phone.Text = "";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (driverid.Text == "")
            {
                driverid.Focus();
                e1.SetError(this.driverid, "Enter driver id");
            }
            else if (name.Text == "")
            {
                name.Focus();
                e1.SetError(this.name, "Enter name");
            }
            else if (driving.Text == "")
            {
                driving.Focus();
                e1.SetError(this.driverid, "Enter driving license number");
            }
            else if (phone.Text == "")
            {
                phone.Focus();
                e1.SetError(this.phone, "Enter phone number");
            }
            else
            {
                e1.Clear();
                if (code == 0)
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM driver_info WHERE driver_id = @BSBS";
                    cmd.Parameters.AddWithValue("@BSBS", driverid.Text);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Driver id already exists\n");
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        try
                        {
                            cmd.CommandText = "INSERT INTO driver_info(driver_id,name,dri_lic_no,phone) VALUES (@bc,@fw,@tw,@f)";
                            cmd.Parameters.AddWithValue("@bc", driverid.Text);
                            cmd.Parameters.AddWithValue("@fw", name.Text);
                            cmd.Parameters.AddWithValue("@tw", driving.Text);
                            cmd.Parameters.AddWithValue("@f", phone.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Data Inserted");
                            ResetData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Data cann't be Insert\n" + ex);
                        }
                    }

                }
                else if (code == 1)
                {
                    if (driverid.Text == AdminPanel.v1 && name.Text == AdminPanel.v2 && driving.Text == AdminPanel.v3 && phone.Text == AdminPanel.v4)
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
                            cmd.CommandText = "UPDATE driver_info SET driver_id=@bc,name=@fw,dri_lic_no=@tw,phone=@f WHERE driver_id = @rn";
                            cmd.Parameters.AddWithValue("@bc", driverid.Text);
                            cmd.Parameters.AddWithValue("@fw", name.Text);
                            cmd.Parameters.AddWithValue("@tw", driving.Text);
                            cmd.Parameters.AddWithValue("@f", phone.Text);
                            cmd.Parameters.AddWithValue("@rn", pk);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Data Updated");
                            ResetData();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Data cann't be Update\n" + ex);
                        }
                    }
                }
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if(name.Text!="")
            {
                char c = name.Text[0];
                if(char.IsLower(c))
                {
                    name.Focus();
                    e1.SetError(this.name, "First letter must be capital");
                }
                else
                {
                    e1.Clear();
                }
            }
            else
            {
                name.Focus();
                e1.SetError(this.name, "Enter name");
            }
        }
    }
}
