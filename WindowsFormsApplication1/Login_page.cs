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
    public partial class Login_page : Form
    {
        public Login_page()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string UserName = UserNameText.Text;
            string Password = PasswordText.Text;

            if (UserName == "Admin1" && Password == "Admin123")
            {
                MessageBox.Show("Login Success !","Login Success !",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                Home_Page obj = new Home_Page ();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Login Not Success ! Try Again.");
            }
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
