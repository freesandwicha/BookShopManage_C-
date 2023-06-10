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


namespace BookShopManage
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            Populate();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
            //Edit
        {
            if (BTitleTb.Text.Length == 0 || BAuthorTb.Text.Length == 0 || BQtyTb.Text.Length == 0 || BCatTb.SelectedIndex == -1)
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
                    string query = "UPDATE BookTable SET BTitle = @Title, BAuthor = @Author, BCat = @Category, BQty = @Quantity, BPrice = @Price WHERE BID = @key";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@Title", BTitleTb.Text);
                        cmd.Parameters.AddWithValue("@Author", BAuthorTb.Text);
                        cmd.Parameters.AddWithValue("@Category", BCatTb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Quantity", BQtyTb.Text);
                        cmd.Parameters.AddWithValue("@Price", BPriceTb.Text);
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



        readonly SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\WhiteBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        //Connect the SQL Server with the Connection String 

        private void Populate()
        //Query the database data and display it on a specific place.
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                string query = "SELECT * FROM BookTable";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, Con))
                {
                    var ds = new DataSet();
                    sda.Fill(ds);
                    BookGridView.DataSource = ds.Tables[0];
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


        private void Filter()
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                string query = "SELECT * FROM BookTable where BCat =  @Category";
                using (SqlDataAdapter sda = new SqlDataAdapter(query, Con))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@Category", CatCbSearchCb.SelectedItem.ToString());
                    var dt = new DataTable();
                    sda.Fill(dt);
                    BookGridView.DataSource = dt;
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



        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text.Length == 0 || BAuthorTb.Text.Length == 0 || BQtyTb.Text.Length == 0 || BCatTb.SelectedIndex == -1)
            {
                MessageBox.Show("Required Fields Empty");
            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();
                    }
                    string query = "INSERT INTO BookTable VALUES (@Title, @Author, @Category, @Quantity, @Price)";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@Title", BTitleTb.Text);
                        cmd.Parameters.AddWithValue("@Author", BAuthorTb.Text);
                        cmd.Parameters.AddWithValue("@Category", BCatTb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Quantity", BQtyTb.Text);
                        cmd.Parameters.AddWithValue("@Price", BPriceTb.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The book's information is saved successfully");
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

        private void CatCbSearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Populate();
            CatCbSearchCb.SelectedIndex = -1;
        }

        private void Reset()
        {
            BTitleTb.Text = "";
            BAuthorTb.Text = "";
            BQtyTb.Text = "";
            BPriceTb.Text = "";
            BCatTb.SelectedIndex = -1;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        int key = 0;
        private void BookGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BTitleTb.Text = BookGridView.SelectedRows[0].Cells[1].Value.ToString();
            BAuthorTb.Text = BookGridView.SelectedRows[0].Cells[2].Value.ToString();
            BCatTb.SelectedItem = BookGridView.SelectedRows[0].Cells[3].Value.ToString();
            BQtyTb.Text = BookGridView.SelectedRows[0].Cells[4].Value.ToString();
            BPriceTb.Text = BookGridView.SelectedRows[0].Cells[5].Value.ToString();

            //The delete function is  connected to  the data grid
            if (BTitleTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BookGridView.SelectedRows[0].Cells[0].Value.ToString());
                //This key will be assigned the value of "BID" from the table.
                //In the subsequent delete operation, the deletion will also be based on the value of "BID" or the key.
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "")
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
                    string query = "DELETE FROM BookTable where BID = @key";
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
    }
}
