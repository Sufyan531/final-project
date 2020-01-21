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
    public partial class BusStaffDetail : Form
    {
        public BusStaffDetail()
        {
            InitializeComponent();
        }

        private void BusStaffDetail_Load(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.busno.Text = "";
            this.drivername.Text = "";
            this.Busroute.Text = "";
            this.r_person.SelectedIndex = -1;
            this.P_name.Text = "";
            this.G_name.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("INSERT INTO busstaff (Bus_no,driver_name,bus_route,severnt,s_name,gaurd) VALUES (@bno,@dname,@route,@servnt,@sname,@Gname)", con);
                b1.Parameters.Add("@bno", busno.Text);
                b1.Parameters.Add("@dname", drivername.Text);
                b1.Parameters.Add("@route", Busroute.Text);
                b1.Parameters.Add("@servnt", r_person.SelectedItem.ToString());
                b1.Parameters.Add("@sname", P_name.Text);
                b1.Parameters.Add("@Gname", G_name.Text);
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED SAVED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not saved");
              
               showStaffDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }



        }

        private void Button4_Click(object sender, EventArgs e)
        {
            showStaffDetail();
        }
        void showStaffDetail()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from busstaff", con);
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
                busno.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                drivername.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Busroute.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                r_person.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                P_name.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                G_name.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Plz double Click");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("delete from busstaff where Bus_no=@bno ", con);
                b1.Parameters.Add("@bno", busno.Text);


                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Delete Succesfully");
                else
                    MessageBox.Show("Not delete");
               
                showStaffDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("not delet");

            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("update busstaff set Bus_no=@bno,driver_name=@dname,bus_route=@route,severnt=@servnt,s_name=@sname,gaurd=@Gname where Bus_no=@bno ", con);
                b1.Parameters.Add("@bno", busno.Text);
                b1.Parameters.Add("@dname", drivername.Text);
                b1.Parameters.Add("@route", Busroute.Text);
                b1.Parameters.Add("@servnt", r_person.SelectedItem.ToString());
                b1.Parameters.Add("@sname", P_name.Text);
                b1.Parameters.Add("@Gname", G_name.Text);
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED Update!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not Update!!!");

                showStaffDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }



        }

        
    }
  }
  


