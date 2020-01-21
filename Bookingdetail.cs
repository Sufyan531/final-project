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
    public partial class Bookingdetail : Form
    {
        CoustomorDetail cd = new CoustomorDetail();
        public Bookingdetail()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Main M3 = new Main();
            M3.Show();
            this.Hide();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand bk1 = new SqlCommand("INSERT INTO booking (CustomorName,CoustomorMobileNumber,CoustomorCnic,root,type,fair,status,pymentmethoed) VALUES (@Cname,@Cmobile,@Ccnic,@root,@type,@fair,@Status,@PMethoed)", con);
                bk1.Parameters.Add("@Cname", C_name.Text);
                bk1.Parameters.Add("@Cmobile", C_mobile.Text);
                bk1.Parameters.Add("@Ccnic", C_Cnic.Text);
                bk1.Parameters.Add("@root", comboBox_root.Text);
                bk1.Parameters.Add("@type", comboBox2_type.SelectedItem.ToString());
                bk1.Parameters.Add("@fair", C_faire.Text);
                bk1.Parameters.Add("@Status", comboBox3_Status.SelectedItem.ToString());
                bk1.Parameters.Add("@PMethoed", comboBox4_pymentMethoed.SelectedItem.ToString());
                int i = bk1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED SAVED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not saved");
                //Button1_Click(sender, e);
                // showDriverDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            C_name.Text = "";
            C_mobile.Text = "";
            C_Cnic.Text = "";
            comboBox_root.SelectedIndex = -1;
            comboBox2_type.SelectedIndex = -1;
            C_faire.Text = "";
            comboBox3_Status.SelectedIndex = -1;
            comboBox4_pymentMethoed.SelectedIndex = -1;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            showBookingDetail(); 
        }
        void showBookingDetail()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from booking", con);
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

                SqlCommand bk1 = new SqlCommand("delete from booking where CustomorName=@Cname ", con);
                bk1.Parameters.Add("@Cname", C_name.Text);


                int i = bk1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Delete Succesfully");
                else
                    MessageBox.Show("Not delete");
                //Button1_Click(sender, e);
               showBookingDetail();
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
                C_name.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                C_mobile.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                C_Cnic.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox_root.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2_type.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                C_faire.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                comboBox3_Status.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                comboBox4_pymentMethoed.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
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

                SqlCommand bk1 = new SqlCommand("update booking set CustomorName=@Cname,CoustomorMobileNumber=@Cmobile,CoustomorCnic=@Ccnic,root=@root,type=@type,fair=@fair,status=@Status,pymentmethoed=@PMethoed where CustomorName=@Cname", con);
                bk1.Parameters.Add("@Cname", C_name.Text);
                bk1.Parameters.Add("@Cmobile", C_mobile.Text);
                bk1.Parameters.Add("@Ccnic", C_Cnic.Text);
                bk1.Parameters.Add("@root", comboBox_root.SelectedItem.ToString());
                bk1.Parameters.Add("@type", comboBox2_type.SelectedItem.ToString());
                bk1.Parameters.Add("@fair", C_faire.Text);
                bk1.Parameters.Add("@Status", comboBox3_Status.SelectedItem.ToString());
                bk1.Parameters.Add("@PMethoed", comboBox4_pymentMethoed.SelectedItem.ToString());
                int i = bk1.ExecuteNonQuery();
                if (i >= 1)
                    
                    MessageBox.Show("Update SuccessFull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Failed");
                
                showBookingDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Recored Not Update");

            }

        }

        private void C_name_TextChanged(object sender, EventArgs e)
        {
            cd.name = C_name.Text;
        }
    }
}
