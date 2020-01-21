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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Haier\Desktop\db\buses.mdf;Integrated Security=True;Connect Timeout=30;");
                con.Open();

                SqlCommand b1 = new SqlCommand("INSERT INTO Employ detail (Eid,Ename,Edep,Edes,Eno,Esalry) VALUES (@eid,@ename,@edep,@edes,@eno,@esalry)", con);
                b1.Parameters.Add("@eid", EId.Text);
                b1.Parameters.Add("@ename", Ename.Text);
                b1.Parameters.Add("@edep", EDep.SelectedItem.ToString());
                b1.Parameters.Add("@edes", Edes.SelectedItem.ToString());
                b1.Parameters.Add("@eno", Econ.Text);
                b1.Parameters.Add("@esalary", Esalary.Text);
                int i = b1.ExecuteNonQuery();
                if (i >= 1)
                    MessageBox.Show("RECORED SAVED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Recored not saved");

                
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("REcored not saved");

            }

        }
    }
}
