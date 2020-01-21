using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_bus
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BusesForm b1 = new BusesForm();
            b1.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DriverDetail d1 = new DriverDetail();
            d1.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Bookingdetail bk1 = new Bookingdetail();
            bk1.Show();
            this.Hide();
        }

        

        private void Button5_Click(object sender, EventArgs e)
        {
            Cargo C1 = new Cargo();
            C1.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            BusStops bs1 = new BusStops();
            bs1.Show();
            this.Hide();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            CustomorBooking c1 = new CustomorBooking();
            c1.Show();
            this.Hide();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            BusStaffDetail s1 = new BusStaffDetail();
            s1.Show();
            this.Hide();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form2 f5 = new Form2();
            f5.Show();
            this.Hide();
        }
    }
}
