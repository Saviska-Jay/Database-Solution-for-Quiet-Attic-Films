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
    public partial class Client_Infomation : Form
    {
        public Client_Infomation()
        {
            InitializeComponent();
        }
        //Connect to the SQL Database
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PNEJN8R;Initial Catalog=The_Quiet_Attic_Films;Integrated Security=True");

        private void Client_Infomation_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int ClientID = int.Parse(ClientIDText.Text);
                string ClientFirstName = FirstNameText.Text;
                string ClientLastName = LastNameText.Text;
                string ContactNumber = ContactNumberText.Text;
                string Email = EmailText.Text;
                int ProductionID = int.Parse(ProductionIDText.Text);

                //SQL Query
                string query_insert = "INSERT INTO Client_Info (Client_ID, Client_First_Name, Client_Last_Name, Client_Contact_No, Client_Email, Production_ID) VALUES (" + ClientID + ",'" + ClientFirstName + "','" + ClientLastName + "','" + ContactNumber + "','" + Email + "'," + ProductionID + ")";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Client Infomation Saved Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Saving Client Infomation ! " + ex);
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int ClientID = int.Parse(ClientIDText.Text);
                string ClientFirstName = FirstNameText.Text;
                string ClientLastName = LastNameText.Text;
                string ContactNumber = ContactNumberText.Text;
                string Email = EmailText.Text;
                int ProductionID = int.Parse(ProductionIDText.Text);

                //SQL Query
                string updateQuery = "UPDATE Client_Info SET Client_First_Name = '" + ClientFirstName + "', Client_Last_Name = '" + ClientLastName + "', Client_Contact_No = '" + ContactNumber + "', Client_Email = '" + Email + "', Production_ID = " + ProductionID + " WHERE Client_ID = " + ClientID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(updateQuery, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Client Infomation Updated Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Updating Client Infomation ! " + ex);
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
                int ClientID = int.Parse(ClientIDText.Text);

                //SQL Query
                string deletesql = "DELETE FROM Client_Info WHERE Client_ID = " + ClientID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(deletesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Client Infomation Deleted Sucessfully ! ");

            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Deleting Client Infomation ! " + ex);
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
                string SearchClientID = SearchClientIDText.Text;
                string query_search = "SELECT * FROM Client_Info WHERE Client_ID = '" + SearchClientID + "'";
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
                MessageBox.Show("Error While Searching Client Infomation ! " + ex);
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
                string SearchClientID = SearchClientIDText.Text;
                string query_search = "SELECT * FROM Client_Info "; 
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
                MessageBox.Show("Error While Searching All Client Infomation ! " + ex);
            }

            finally
            {
                //Close the connection
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductionIDText_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
