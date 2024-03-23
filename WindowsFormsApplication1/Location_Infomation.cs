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
    public partial class Location_Infomation : Form
    {
        public Location_Infomation()
        {
            InitializeComponent();
        }
        //Connect to the SQL Database
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PNEJN8R;Initial Catalog=The_Quiet_Attic_Films;Integrated Security=True");

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int LocationID = int.Parse(LocationIDText.Text);
                string LocationName = LocationNameText.Text;
                string AddressNo = AddressNoTextBox.Text;
                string AddressStreet = AddressStreetTextBox.Text;
                string AddressCity = AddressCityTextBox.Text;
                string TeleNumber = LocationTeleText.Text;
                int ProductionID = int.Parse(ProductionIDText.Text);

                //SQL Query
                string query_insert = "INSERT INTO Location_Info (Location_ID, Location_Name, Location_Address_No, Location_Address_Street,Location_Address_City,Location_Telephone_Number,Production_ID) VALUES (" + LocationID + ",'" + LocationName + "','" + AddressNo + "','" + AddressStreet + "','" + AddressCity + "','" + TeleNumber + "'," + ProductionID + ")";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Location Infomation Saved Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Saving Location Infomation ! " + ex);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int LocationID = int.Parse(LocationIDText.Text);
                string LocationName = LocationNameText.Text;
                string AddressNo = AddressNoTextBox.Text;
                string AddressStreet = AddressStreetTextBox.Text;
                string AddressCity = AddressCityTextBox.Text;
                string TeleNumber = LocationTeleText.Text;
                int ProductionID = int.Parse(ProductionIDText.Text);

                //SQL Query
                string query_update = "UPDATE Location_Info SET Location_Name = '" + LocationName + "', Location_Address_No = '" + AddressNo + "', Location_Address_Street = '" + AddressStreet + "', Location_Address_City = '" + AddressCity + "', Location_Telephone_Number = '" + TeleNumber + "', Production_ID = " + ProductionID + " WHERE Location_ID = " + LocationID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_update, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Location Infomation Updated Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Updating Location Infomation ! " + ex);
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
                int LocationID = int.Parse(LocationIDText.Text);

                //SQL Query
                string deletesql = "DELETE FROM Location_Info WHERE Location_ID = " + LocationID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(deletesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Location Infomation Deleted Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Deleting Location Infomation ! " + ex);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string SearchLocationID = SearchLocationIDText.Text;
                string query_search = "SELECT * FROM Location_Info WHERE Location_ID = '" + SearchLocationID + "'";
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
                MessageBox.Show("Error While Searching Location Infomation ! " + ex);
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
                string SearchLocationID = SearchLocationIDText.Text;
                string query_search = "SELECT * FROM Location_Info ";
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
                MessageBox.Show("Error While Showing All Location Infomation ! " + ex);
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
    }
}
