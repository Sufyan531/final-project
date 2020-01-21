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
    public partial class Cargo : Form
    {
        public Cargo()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Varchar.Text = "";
            this.Coustomor.Text = "";
            this.Cnic.Text = "";
            this.SenderPhnNo.Text = "";
            this.ReceverPhnNo.Text = "";
            this.Item.Text = "";
            this.route.SelectedIndex = -1;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("INSERT INTO Cargo (Voucher,coustomor,cnic,SenderNo,ReciverNo,Item,Route) VALUES (@varcher,@customer,@cnic,@senderNo,@recevierNo,@item,@route)", con);
                b1.Parameters.Add("@varcher", Varchar.Text);
                b1.Parameters.Add("@customer", Coustomor.Text);
                b1.Parameters.Add("@senderNo", SenderPhnNo.Text);
                b1.Parameters.Add("@recevierNo", ReceverPhnNo.Text);
                b1.Parameters.Add("@item", Item.Text);
                b1.Parameters.Add("@cnic", Cnic.Text);
                b1.Parameters.Add("@route", route.SelectedItem.ToString());
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED SAVED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not saved");
                //Button1_Click(sender, e);
                showCargoDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Main m4 = new Main();
            m4.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            showCargoDetail();

        }
        void showCargoDetail()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");

            SqlDataAdapter sda = new SqlDataAdapter("select * from Cargo ", con);
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
                

            }

        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Varchar.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Coustomor.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Cnic.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                SenderPhnNo.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                ReceverPhnNo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Item.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                route.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
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

                SqlCommand b1 = new SqlCommand("delete from Cargo where Voucher=@varcher ", con);
                b1.Parameters.Add("@varcher", Varchar.Text);


                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Delete Succesfully");
                else
                    MessageBox.Show("Not delete");
                
                showCargoDetail();
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

                SqlCommand b1 = new SqlCommand("update Cargo set Voucher=@varcher,coustomor=@customer,cnic=@cnic,SenderNo=@senderNo,ReciverNo=@recevierNo,Item=@item,Route=@route where Voucher=@varcher ", con);
                b1.Parameters.Add("@varcher", Varchar.Text);
                b1.Parameters.Add("@customer", Coustomor.Text);
                b1.Parameters.Add("@senderNo", SenderPhnNo.Text);
                b1.Parameters.Add("@recevierNo", ReceverPhnNo.Text);
                b1.Parameters.Add("@item", Item.Text);
                b1.Parameters.Add("@cnic", Cnic.Text);
                b1.Parameters.Add("@route", route.SelectedItem.ToString());
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("Update Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not Update");
                
                showCargoDetail();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }

        }
    }
 }

