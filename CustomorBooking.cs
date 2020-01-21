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
    public partial class CustomorBooking : Form
    {
        public CustomorBooking()
        {
            InitializeComponent();
        }

        private void CustomorBooking_Load(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("INSERT INTO CoustomorBooking (id,C_name,C_mobile,C_Cnic,route,seat_no,status,p_methoed) VALUES (@id,@name,@mobile,@cnic,@route,@seat,@stus,@Pmethd)", con);
                b1.Parameters.Add("@id", C_id.Text);
                b1.Parameters.Add("@name", C_name.Text);
                b1.Parameters.Add("@mobile", C_phn.Text);
                b1.Parameters.Add("@cnic", c_cnic.Text);
                b1.Parameters.Add("@route", C_ROUTE.Text);
                b1.Parameters.Add("@seat", C_seat.SelectedItem.ToString());
                b1.Parameters.Add("@stus", C_seatStatus.SelectedItem.ToString());
                b1.Parameters.Add("@Pmethd", C_Pmehtoed.SelectedItem.ToString());
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED SAVED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not saved");
                
                showCustomorDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }




        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            C_id.Text = "";
            C_name.Text = "";
            C_phn.Text = "";
            c_cnic.Text = "";
            C_ROUTE.SelectedIndex = -1;
            C_seat.SelectedIndex = -1;
            C_seatStatus.SelectedIndex = -1;
            C_Pmehtoed.SelectedIndex = -1;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            showCustomorDetail();
        }
        void showCustomorDetail()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from CoustomorBooking", con);
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
                dataGridView1.Rows[n].Cells[6].Value = dr[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr[7].ToString();

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("delete from CoustomorBooking where id=@id ", con);
                b1.Parameters.Add("@id", C_id.Text);


                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Delete Succesfully");
                else
                    MessageBox.Show("Not delete");
                
                showCustomorDetail();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("not delet");

            }



        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                C_id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                C_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                C_phn.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                c_cnic.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                C_ROUTE.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                C_seat.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                C_seatStatus.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                C_Pmehtoed.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Plz double Click");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
            con.Open();

            SqlCommand b1 = new SqlCommand("update CoustomorBooking set id=@id,C_name=@name,C_mobile=@mobile,C_Cnic=@cnic,route=@route,seat_no=@seat,status=@stus,p_methoed=@Pmethd where id=@id", con);
            b1.Parameters.Add("@id", C_id.Text);
            b1.Parameters.Add("@name", C_name.Text);
            b1.Parameters.Add("@mobile", C_phn.Text);
            b1.Parameters.Add("@cnic", c_cnic.Text);
            b1.Parameters.Add("@route", C_ROUTE.Text);
            b1.Parameters.Add("@seat", C_seat.SelectedItem.ToString());
            b1.Parameters.Add("@stus", C_seatStatus.SelectedItem.ToString());
            b1.Parameters.Add("@Pmethd", C_Pmehtoed.SelectedItem.ToString());
            int i = b1.ExecuteNonQuery();
            if (i >= 1)
                MessageBox.Show("RECORED Update!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Recored not saved");

            showCustomorDetail();
            con.Close();
        }
    }
}

