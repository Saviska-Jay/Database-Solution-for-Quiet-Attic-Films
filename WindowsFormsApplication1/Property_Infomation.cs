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
    public partial class Property_Infomation : Form
    {
        public Property_Infomation()
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
                int PropertyID = int.Parse(PropertyIDText.Text);
                string PropertyType = comboBox1.SelectedItem.ToString();
                int Rent = int.Parse(RentText.Text);
                int ProductionID = int.Parse(ProductionIDText.Text);
                
                //SQL Query
                string query_insert = "INSERT INTO Property_Info (Property_ID, Property_Type, Property_Rent, Production_ID) VALUES (" + PropertyID + ",'" + PropertyType + "'," + Rent + "," + ProductionID + ")";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Property Infomation Saved Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Saving Property Infomation ! " + ex);
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
                int PropertyID = int.Parse(PropertyIDText.Text);
                string PropertyType = comboBox1.SelectedItem.ToString();
                int Rent = int.Parse(RentText.Text);
                int ProductionID = int.Parse(ProductionIDText.Text);

                //SQL Query
                string query_update = "UPDATE Property_Info SET Property_Type = '" + PropertyType + "', Property_Rent = " + Rent + ", Production_ID = " + ProductionID + " WHERE Property_ID = " + PropertyID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_update, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Property Infomation Updated Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Updating Property Infomation ! " + ex);
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
                int PropertyID = int.Parse(PropertyIDText.Text);

                //SQL Query
                string deletesql = "DELETE FROM Property_Info WHERE Property_ID = " + PropertyID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(deletesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Property Infomation Deleted Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Deleting Property Infomation ! " + ex);
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
                string SearchPropertyID = SearchPropertyIDText.Text;
                string query_search = "SELECT * FROM Property_Info WHERE Property_ID = '" + SearchPropertyID + "'";
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
                MessageBox.Show("Error While Searching Property Infomation ! " + ex);
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
                string SearchPropertyID = SearchPropertyIDText.Text;
                string query_search = "SELECT * FROM Property_Info ";
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
                MessageBox.Show("Error While Searching Property Infomation ! " + ex);
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

        private void Property_Infomation_Load(object sender, EventArgs e)
        {

        }
    }
}
