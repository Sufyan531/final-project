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
    public partial class DriverDetail : Form
    {
        public DriverDetail()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand d1 = new SqlCommand("update Driver set Id=@id,Name=@name,F_Name=@fname,Cnic=@cnic,Route=@route where Id=@id", con);
                d1.Parameters.Add("@id", DriverId.Text);
                d1.Parameters.Add("@name", DriverName.Text);
                d1.Parameters.Add("@fname", FatherName.Text);
                d1.Parameters.Add("@cnic", Cnic.Text);
                d1.Parameters.Add("@route", comboBox2.SelectedItem.ToString());
                int i = d1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Update SuccessFull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Failed");
                Button1_Click(sender, e);
                showDriverDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanks For update");

            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Main m1 = new Main();
            m1.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.DriverId.Text = "";
            this.DriverName.Text = "";
            this.FatherName.Text = "";
            this.Cnic.Text = "";
            this.comboBox2.SelectedIndex = -1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand d1 = new SqlCommand("INSERT INTO Driver (Id,Name,F_Name,Cnic,Route) VALUES (@id,@name,@fname,@cnic,@route)", con);
                d1.Parameters.Add("@id", DriverId.Text);
                d1.Parameters.Add("@name", DriverName.Text);
                d1.Parameters.Add("@fname", FatherName.Text);
                d1.Parameters.Add("@cnic", Cnic.Text);
                d1.Parameters.Add("@route", comboBox2.SelectedItem.ToString());

                int i = d1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED SAVED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not saved");
                //Button1_Click(sender, e);
                showDriverDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand d1 = new SqlCommand("delete from Driver where Id=@id ", con);
                 d1.Parameters.Add("@id", DriverId.Text);


                int i = d1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Delete Succesfully");
                else
                    MessageBox.Show("Not delete");
                //Button1_Click(sender, e);
               showDriverDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("not delet");

            }

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            showDriverDetail();
            
        }
        void showDriverDetail()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Driver",con);
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

            }

        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DriverId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DriverName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                FatherName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Cnic.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Plz double Click");
            }

        }
    }
}
