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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\login.mdf;Integrated Security=True;Connect Timeout=30;");
            string query="Select * from LOGIN where USERNAME='" + textBox1.Text.Trim() + "' and PASSWORD ='" + textBox3.Text.Trim() +"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1) 
            {
                this.Hide();
                Main f1 = new Main();
                f1.Show();

            }
            else
            {
                MessageBox.Show("UserName and password is wrong");
            }
            

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
