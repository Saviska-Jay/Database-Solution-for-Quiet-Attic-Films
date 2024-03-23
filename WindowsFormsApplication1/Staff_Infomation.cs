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

namespace WindowsFormsApplication1
{
    public partial class Staff_Infomation : Form
    {
        public Staff_Infomation()
        {
            InitializeComponent();

        }

        //Connect to the SQL Database
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PNEJN8R;Initial Catalog=The_Quiet_Attic_Films;Integrated Security=True");


        private void Staff_Infomation_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int StaffID = int.Parse(StaffIDTextBox.Text);
                string FirstName = FirstNameTextBox.Text;
                string LastName = LastNameTextBox.Text;

                string Birtdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");


                string StaffType = comboBox1.SelectedItem.ToString();


                int StaffFee = int.Parse(StaffFeeTextBox.Text);

                string AddressNo = AddressNoTextBox.Text;
                string AddressStreet = AddressStreetTextBox.Text;
                string AddressCity = AddressCityTextBox.Text;

                int ContactNumber = int.Parse(ContactNumberTextBox.Text);
                int ProductionID = int.Parse(ProductionIDTextBox.Text);


                //SQL Query
                string query_insert = "INSERT INTO Staff_Info (Staff_ID, Staff_First_Name, Staff_Last_Name, Staff_Birth_Of_Date, Staff_Type, Staff_Fee, Staff_Address_No, Staff_Address_Street, Staff_Address_City, Staff_Contact_No, Production_ID) VALUES (" + StaffID + ",'" + FirstName + "','" + LastName + "','" + Birtdate + "','" + StaffType + "'," + StaffFee + ",'" + AddressNo + "','" + AddressStreet + "','" + AddressCity + "'," + ContactNumber + "," + ProductionID + ")";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Staff Infomation Saved Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Saving Staff Infomation ! " + ex);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int StaffID = int.Parse(StaffIDTextBox.Text);
                string FirstName = FirstNameTextBox.Text;
                string LastName = LastNameTextBox.Text;

                string Birtdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");


                string StaffType = comboBox1.SelectedItem.ToString();


                int StaffFee = int.Parse(StaffFeeTextBox.Text);

                string AddressNo = AddressNoTextBox.Text;
                string AddressStreet = AddressStreetTextBox.Text;
                string AddressCity = AddressCityTextBox.Text;

                int ContactNumber = int.Parse(ContactNumberTextBox.Text);
                int ProductionID = int.Parse(ProductionIDTextBox.Text);


                //SQL Query
                string updateQuery = "UPDATE Staff_Info SET Staff_First_Name = '"+FirstName+"', Staff_Last_Name = '"+LastName+"', Staff_Birth_Of_Date = '"+Birtdate+"', Staff_Type = '"+StaffType+"', Staff_Fee = '"+StaffFee+"', Staff_Address_No = '"+AddressNo+"', Staff_Address_Street = '"+AddressStreet+"', Staff_Address_City = '"+AddressCity+"', Staff_Contact_No = "+ContactNumber+", Production_ID = "+ProductionID+" WHERE Staff_ID = "+StaffID; 
                //SQL Command
                SqlCommand cmnd = new SqlCommand(updateQuery, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Staff Infomation Updated Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Updating Staff Infomation ! " + ex);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int StaffID = int.Parse(StaffIDTextBox.Text);

                //SQL Query
                string deletesql = "DELETE FROM Staff_Info WHERE Staff_ID = " + StaffID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(deletesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Staff Infomation Deleted Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Deleting Staff Infomation ! " + ex);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page obj = new Home_Page();
            obj.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string SearchStaffID = StaffIDSearchTextBox.Text;
                string query_search = "SELECT * FROM Staff_Info WHERE Staff_ID = '" + SearchStaffID + "'";
                con.Open();
                SqlCommand cmnd = new SqlCommand(query_search, con);
                SqlDataReader r = cmnd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(r);

                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Searching Staff Infomation ! " + ex);
            }

            finally
            {
                //Close the connection
                con.Close();
            }
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                string SearchProductionID = StaffIDSearchTextBox.Text;
                string query_search = "SELECT * FROM Staff_Info";
                con.Open();
                SqlCommand cmnd = new SqlCommand(query_search, con);
                SqlDataReader r = cmnd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(r);

                dataGridView1.DataSource = dt;
            }

            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Searching Staff Infomation ! " + ex);
            }

            finally
            {
                //Close the connection
                con.Close();
            }
        }

    }
}
