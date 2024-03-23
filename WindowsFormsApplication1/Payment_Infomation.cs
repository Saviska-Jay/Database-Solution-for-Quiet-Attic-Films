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
    public partial class Payment_Infomation : Form
    {
        public Payment_Infomation()
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
                int PaymentInvoice = int.Parse(PaymentInvoiceText.Text);
                string PaymentType = comboBox1.SelectedItem.ToString();
                int PAmount = int.Parse(PaymentAmountText.Text);
                int ClientID = int.Parse(ClientIDText.Text);

                //SQL Query
                string query_insert = "INSERT INTO Payment_Info (Payment_Invoice, Payment_Method, Payment_Amount, Client_ID) VALUES (" + PaymentInvoice + ",'" + PaymentType + "'," + PAmount + "," + ClientID + ")";
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_insert, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Payment Infomation Saved Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Saving Payment Infomation ! " + ex);
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
                int PaymentInvoice = int.Parse(PaymentInvoiceText.Text);
                string PaymentType = comboBox1.SelectedItem.ToString();
                int PAmount = int.Parse(PaymentAmountText.Text);
                int ClientID = int.Parse(ClientIDText.Text);

                //SQL Query
                string query_update = "UPDATE Payment_Info SET Payment_Method = '" + PaymentType + "', Payment_Amount = " + PAmount + ", Client_ID = " + ClientID + " WHERE Payment_Invoice = " + PaymentInvoice;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(query_update, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Payment Infomation Updated Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Updating Payment Infomation ! " + ex);
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
                int PaymentInvoice = int.Parse(PaymentInvoiceText.Text);

                //SQL Query
                string deletesql = "DELETE FROM Payment_Info WHERE Payment_Invoice = " + PaymentInvoice;
                //SQL Command
                SqlCommand cmnd = new SqlCommand(deletesql, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                //Sucessfull Message 
                MessageBox.Show("Payment Infomation Deleted Sucessfully ! ");
            }
            catch (Exception ex)
            {
                //Erorr Message 
                MessageBox.Show("Error While Deleting Payment Infomation ! " + ex);
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
                string SearchPaymentID = SearchPaymentIDText.Text;
                string query_search = "SELECT * FROM Payment_Info WHERE Payment_Invoice = '" + SearchPaymentID + "'";
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
                MessageBox.Show("Error While Searching Payment Infomation ! " + ex);
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
                string SearchPaymentID = SearchPaymentIDText.Text;
                string query_search = "SELECT * FROM Payment_Info";
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
                MessageBox.Show("Error While Showing All Payment Infomation ! " + ex);
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
