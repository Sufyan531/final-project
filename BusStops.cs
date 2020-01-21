using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace project_bus
{
    public partial class BusStops : Form
    {
        public BusStops()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Main m5 = new Main();
            m5.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.StopId.Text = "";
            this.S_name.Text = "";
            this.C_distence.Text = "";
            this.R_time.Text = "";
            this.SPoint.SelectedIndex = -1;
            this.EPoint.SelectedIndex = -1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                    con.Open();

                    SqlCommand b1 = new SqlCommand("INSERT INTO BusStops1 (Stop_Id,Stop_Name,City_Distence,Reched_Time,S_point,E_point) VALUES (@Sid,@Sname,@cDis,@Rtime,@spoint,@epoint)", con);
                    b1.Parameters.Add("@Sid", StopId.Text);
                    b1.Parameters.Add("@Sname", S_name.Text);
                    b1.Parameters.Add("@cDis", C_distence.Text);
                    b1.Parameters.Add("@Rtime", R_time.Text);
                    b1.Parameters.Add("@spoint", SPoint.SelectedItem.ToString());
                    b1.Parameters.Add("@epoint", EPoint.SelectedItem.ToString());
                    int i = b1.ExecuteNonQuery();
                    if (i >= 1)
                        MessageBox.Show("RECORED SAVED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Recored not saved");
                    //Button1_Click(sender, e);
                    showStopDetial();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("REcored not saved");

                }


            }

        private void Button4_Click(object sender, EventArgs e)
        {
            showStopDetial();
        }

        void showStopDetial()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from BusStops1", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();
                

            }

        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                StopId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                S_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                C_distence.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                R_time.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                SPoint.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                EPoint.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Plz double Click");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("update BusStops1 set Stop_Id=@Sid,Stop_Name=@Sname,City_Distence=@cDis,Reched_Time=@Rtime,S_point=@spoint,E_point=@epoint where Stop_Id=@Sid", con);
                b1.Parameters.Add("@Sid", StopId.Text);
                b1.Parameters.Add("@Sname", S_name.Text);
                b1.Parameters.Add("@cDis", C_distence.Text);
                b1.Parameters.Add("@Rtime", R_time.Text);
                b1.Parameters.Add("@spoint", SPoint.SelectedItem.ToString());
                b1.Parameters.Add("@epoint", EPoint.SelectedItem.ToString());
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Update SuccessFull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Failed");
                //Button1_Click(sender, e);
                showStopDetial();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not Update");

            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("delete from BusStops1 where Stop_Id=@Sid ", con);
                b1.Parameters.Add("@Sid", StopId.Text);


                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Delete Succesfully");
                else
                    MessageBox.Show("Not delete");
                //Button1_Click(sender, e);
                showStopDetial();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("not delet");

            }

        }
    }
  }


