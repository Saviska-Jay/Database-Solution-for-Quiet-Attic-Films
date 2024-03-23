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
    public partial class Production_Infomation : Form
    {
        public Production_Infomation()
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
                int ProductionID = int.Parse(ProductionIDText.Text);
                string ProductionName = ProductionNameText.Text;
                string ProductionDescription = ProductionDescriptionRichText.Text;
                int Budget = int.Parse(BudgetText.Text);
                string ProductionType;
                if (ADradioButton1.Checked)
                {
                    ProductionType = "Advertisement";
                }
                else
                {
                    ProductionType = "Short Film";

                }
                string ProductionDuration = ProductionDurationText.Text;

                //SQL Query
                string query_insert = "INSERT INTO Production_Info (Production_ID, Production_Name, Production_Description, Budget, Production_Type, Production_Duration) VALUES (" + ProductionID + ",'" + ProductionName + "','" + ProductionDescription + "'," + Budget + ",'" + ProductionType + "','" + ProductionDuration + "')";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Production Infomation Saved Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Saving Production Infomation ! " + ex);
            }
            finally
            {
                //Close the connection
                con.Close();
            }
        }
        //Close the program using "Exit button"
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from GUI
                int ProductionID = int.Parse(ProductionIDText.Text);
                string ProductionName = ProductionNameText.Text;
                string ProductionDescription = ProductionDescriptionRichText.Text;
                int Budget = int.Parse(BudgetText.Text);
                string ProductionType;
                if (ADradioButton1.Checked)
                {
                    ProductionType = "Advertisement";
                }
                else
                {
                    ProductionType = "Short Film";

                }
                string ProductionDuration = ProductionDurationText.Text;

                //SQL Query
                string updatesql = "UPDATE Production_Info SET Production_Name = '" + ProductionName + "', Production_Description = '" + ProductionDescription + "', Budget = " + Budget + ", Production_Type = '" + ProductionType + "', Production_Duration = '" + ProductionDuration + "' WHERE Production_ID = " + ProductionID+"";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(updatesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Production Infomation Updated Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Updating Production Infomation ! " + ex);
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
                int ProductionID = int.Parse(ProductionIDText.Text);

                //SQL Query
                string deletesql = "DELETE FROM Production_Info WHERE Production_ID = " + ProductionID;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(deletesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Production Infomation Deleted Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Deleting Production Infomation ! " + ex);
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string SearchProductionID = SearchProductionIDText.Text;
                string query_search = "SELECT * FROM Production_Info WHERE Production_ID = '" + SearchProductionID + "'";
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
                MessageBox.Show("Error While Searching Production Infomation ! " + ex);
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
                string SearchProductionID = SearchProductionIDText.Text;
                string query_search = "SELECT * FROM Production_Info";
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
                MessageBox.Show("Error While Searching Production Infomation ! " + ex);
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
    }
}
