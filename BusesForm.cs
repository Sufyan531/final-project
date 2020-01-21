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
    public partial class BusesForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
        public BusesForm()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Main m1 = new Main();
            m1.Show();
            
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            this.BusNO.Text = "";
            this.Buscontrol.Text = "";
            this.Buschasis.Text = "";
            comboBox1.SelectedIndex = -1;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("INSERT INTO buses (BusNO,BusChasis,BusControl,Type) VALUES (@BusNO,@BusChasis,@BusControl,@Type)", con);
                b1.Parameters.Add("@BusNO", BusNO.Text);
                b1.Parameters.Add("@BusChasis", Buschasis.Text);
                b1.Parameters.Add("@BusControl", Buscontrol.Text);
                b1.Parameters.Add("@Type", comboBox1.SelectedItem.ToString());
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED SAVED","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not saved");
                Button1_Click(sender, e);
                showBusDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }








        }


        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void BusesForm_Load(object sender, EventArgs e)
        {

        }

        void showBusDetail()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select * from buses", con);
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

            }

        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                BusNO.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Buscontrol.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Buschasis.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Plz double Click");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            showBusDetail();
        }

   
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("delete from buses where BusNO=@BusNO ", con);
                b1.Parameters.Add("@BusNO", BusNO.Text);
                

                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Delete Succesfully");
                else
                    MessageBox.Show("Not delete");
                Button1_Click(sender, e);
                showBusDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("not delet");

            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();
                
                SqlCommand b1 = new SqlCommand("update buses set BusNo=@BusNO,BusChasis=@BusChasis,BusControl=@BusControl,Type=@Type where BusNo=@BusNo", con);
                b1.Parameters.Add("@BusNO", BusNO.Text);
                b1.Parameters.Add("@BusChasis", Buschasis.Text);
                b1.Parameters.Add("@BusControl", Buscontrol.Text);
                b1.Parameters.Add("@Type", comboBox1.SelectedItem.ToString());
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Update SuccessFull!!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Failed");
                Button1_Click(sender, e);
                showBusDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Recored Not Update");

            }

        }

        
    }
}