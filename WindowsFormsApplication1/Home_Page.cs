using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProductionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Production_Infomation obj = new Production_Infomation ();
            obj.Show();
        }

        private void StaffButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff_Infomation obj = new Staff_Infomation();
            obj.Show();
        }

        private void ClientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client_Infomation obj = new Client_Infomation();
            obj.Show();
        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Location_Infomation obj = new Location_Infomation();
            obj.Show();
        }

        private void PropertyButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Property_Infomation obj = new Property_Infomation();
            obj.Show();
        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment_Infomation obj = new Payment_Infomation();
            obj.Show();
        }
    }
}
