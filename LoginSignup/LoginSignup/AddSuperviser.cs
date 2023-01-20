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
    public partial class AddSuperviser : Form
    {
        static int code;
        string pk;
        public AddSuperviser()
        {
            InitializeComponent();
            if (code == 0)
            {
                label1.Text = "Add Superviser";
            }
            else if (code == 1)
            {
                label1.Text = "Edit Superviser";
                superid.Text = AdminPanel.v1;
                name.Text = AdminPanel.v2;
                nid.Text = AdminPanel.v3;
                phone.Text = AdminPanel.v4;
                pass.Text = AdminPanel.v5;
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
            superid.Text = "";
            name.Text = "";
            pass.Text = "";
            phone.Text = "";
            nid.Text = "";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (code == 0)
            {
                MySqlConnection con = new MySqlConnection(AppSettings.Connection());
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM supervisor_info WHERE superviser_id = @BSBS";
                cmd.Parameters.AddWithValue("@BSBS", superid.Text);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("This Supervisor Id already exists\n");
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    try
                    {
                        cmd.CommandText = "INSERT INTO supervisor_info(superviser_id,name,nid,phone,pass) VALUES (@bc,@fw,@tw,@f,@P)";
                        cmd.Parameters.AddWithValue("@bc", superid.Text);
                        cmd.Parameters.AddWithValue("@fw", name.Text);
                        cmd.Parameters.AddWithValue("@tw", nid.Text);
                        cmd.Parameters.AddWithValue("@f", phone.Text);
                        cmd.Parameters.AddWithValue("@P", pass.Text);
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
                if (superid.Text == AdminPanel.v1 && name.Text == AdminPanel.v2 && nid.Text == AdminPanel.v3 && phone.Text == AdminPanel.v4 && pass.Text == AdminPanel.v5)
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
                        cmd.CommandText = "UPDATE supervisor_info SET superviser_id=@bc,name=@fw,nid=@tw,phone=@f,pass=@P WHERE superviser_id = @rn";
                        cmd.Parameters.AddWithValue("@bc", superid.Text);
                        cmd.Parameters.AddWithValue("@fw", name.Text);
                        cmd.Parameters.AddWithValue("@tw", nid.Text);
                        cmd.Parameters.AddWithValue("@f", phone.Text);
                        cmd.Parameters.AddWithValue("@P", pass.Text);
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
}
