using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopManage
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Populate();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        readonly SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\WhiteBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
            //SAVE 
        {
            if (UnameTb.Text.Length == 0 || UPhoneTb.Text.Length == 0 || UAddressTb.Text.Length == 0 || UPwdTb.Text.Length == 0)
            {
                MessageBox.Show("Required Fields Empty");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO UsersTable VALUES (@UName, @UPhone, @UAddress, @UPassword)";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@UName", UnameTb.Text);
                        cmd.Parameters.AddWithValue("@UPhone", UPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@UAddress", UAddressTb.Text);
                        cmd.Parameters.AddWithValue("@UPassword", UPwdTb.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The user's information is saved successfully");
                    }
                    Populate();
                    //when user saves a book, the UI will query the database again.
                    Reset();
                    //The UI will reset the input.
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    // Always ensure the connection is closed
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }
            }
        }
        private void Populate()
        //Query the database data and display it on a specific place.
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                string query = "SELECT * FROM UsersTable";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, Con))
                {
                    var ds = new DataSet();
                    sda.Fill(ds);
                    UserGridView.DataSource = ds.Tables[0];
                    
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Always ensure the connection is closed
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text.Length == 0 || UPhoneTb.Text.Length == 0 || UAddressTb.Text.Length == 0 || UPwdTb.Text.Length == 0)
            //That means no title has been choosen.
            {
                MessageBox.Show("Missing information.");
            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string query = "UPDATE UsersTable SET UName = @UnameTb, UPhone = @UPhoneTb, UAddress = @UAddressTb, UPassword = @UPwdTb WHERE UID = @key";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@UnameTb", UnameTb.Text);
                        cmd.Parameters.AddWithValue("@UPhoneTb", UPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@UAddressTb", UAddressTb.Text);
                        cmd.Parameters.AddWithValue("@UPwdTb", UPwdTb.Text);
                        cmd.Parameters.AddWithValue("@key", key);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Changes Saved Successfully");
                    }
                    Populate();
                    //when user deletes a book, the UI will query the database again.
                    Reset();
                    //The UI will reset the input.
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    // Always ensure the connection is closed
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }
            }
        }

        private void Reset()
        {
            UnameTb.Text = "";
            UPhoneTb.Text = "";
            UAddressTb.Text = "";
            UPwdTb.Text = "";

        }
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        int key = 0;

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "")
            //That means no title has been choosen.
            {
                MessageBox.Show("Connot delete nothing");
            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string query = "DELETE FROM UsersTable where UID = @key";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@key", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successful deletion");
                    }
                    Populate();
                    //when user deletes a book, the UI will query the database again.
                    Reset();
                    //The UI will reset the input.
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    // Always ensure the connection is closed
                    if (Con.State == ConnectionState.Open)
                    {
                        Con.Close();
                    }
                }
            }
        }

        private void UserGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserGridView.SelectedRows[0].Cells[1].Value.ToString();
            UPhoneTb.Text = UserGridView.SelectedRows[0].Cells[2].Value.ToString();
            UAddressTb.Text = UserGridView.SelectedRows[0].Cells[3].Value.ToString();
            UPwdTb.Text = UserGridView.SelectedRows[0].Cells[4].Value.ToString();

            //The delete function is  connected to  the data grid
            if (UnameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserGridView.SelectedRows[0].Cells[0].Value.ToString());
                //This key will be assigned the value of "BID" from the table.
                //In the subsequent delete operation, the deletion will also be based on the value of "BID" or the key.
            }
        }
    }
}
