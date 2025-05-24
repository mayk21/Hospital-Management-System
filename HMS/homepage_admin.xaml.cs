using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace HMS
{
    public partial class homepage_admin : Window
    {
        public homepage_admin()
        {
            InitializeComponent();
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");
        DataSet ds = new DataSet();

        // Method to clear all input fields
        public void clear()
        {
            Name.Clear();
            Email.Clear();
            Password.Clear();
            Phone.Clear();
            Fees.Clear();
            Specialization.Clear();
            Search.Clear();
        }

        // Method to load data from the database into the data grid
        public void loadgrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT id,name,email,phone,fees,specialization FROM doctor_info", Sqlobj);
            DataTable dt = new DataTable();
            Sqlobj.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Sqlobj.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        // Method to validate the input fields
        public bool validation()
        {
            // Check if any field is empty or contains only whitespace
            if (String.IsNullOrEmpty(Name.Text) || String.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            else if (String.IsNullOrEmpty(Email.Text) || String.IsNullOrWhiteSpace(Email.Text))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            else if (String.IsNullOrEmpty(Password.Password) || String.IsNullOrWhiteSpace(Password.Password))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            else if (String.IsNullOrEmpty(Phone.Text) || String.IsNullOrWhiteSpace(Phone.Text))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            else if (String.IsNullOrEmpty(Fees.Text) || String.IsNullOrWhiteSpace(Fees.Text))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            else if (String.IsNullOrEmpty(Specialization.Text) || String.IsNullOrWhiteSpace(Specialization.Text))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            // Validate email format using regular expressions
            else if (!Regex.Match(Email.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").Success)
            {
                MessageBox.Show("Enter Valid Email address", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Add Button
        {
            // Validate input before proceeding
            if (validation())
            {
                SqlCommand cmd1 = new SqlCommand("SELECT id,name,email,phone,fees,specialization FROM doctor_info WHERE email = '" + Email.Text + "' OR phone = '" + Phone.Text + "'", Sqlobj);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    // Check if email or phone already exists
                    if (ds.Tables[0].Rows[0]["email"].ToString() == Email.Text)
                    {
                        MessageBox.Show("Email: " + Email.Text + " already exists.");
                    }
                    else if (ds.Tables[0].Rows[0]["phone"].ToString() == Phone.Text)
                    {
                        MessageBox.Show("Contact: " + Phone.Text + " already exists.");
                    }
                    ds.Clear();
                    clear();
                }
                else
                {
                    // Insert new doctor information into the database
                    SqlCommand cmd = new SqlCommand("INSERT INTO doctor_info VALUES (@name,@email,@password,@phone,@fees,@specialization)", Sqlobj);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", Name.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@password", SecureData.HashString(Password.Password)); // Hash password for security
                    cmd.Parameters.AddWithValue("@phone", Phone.Text);
                    cmd.Parameters.AddWithValue("@fees", Fees.Text);
                    cmd.Parameters.AddWithValue("@specialization", Specialization.Text);

                    Sqlobj.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully added", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clear();
                    Sqlobj.Close();
                    loadgrid();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Search Button
        {
            try
            {
                if (Sqlobj.State == ConnectionState.Closed)
                    Sqlobj.Open();

                string query = "SELECT id,name,email,phone,fees,specialization FROM doctor_info WHERE id LIKE @UserID";
                using (SqlCommand cmd = new SqlCommand(query, Sqlobj))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", "%" + Search.Text + "");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);
                    if (dataTable.Rows.Count == 0) // Check if no records found
                    {
                        MessageBox.Show("No records found");
                    }
                    else
                    {
                        datagrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Sqlobj.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Delete Button
        {
            if (Sqlobj.State == ConnectionState.Closed)
                Sqlobj.Open();

            string query = "DELETE FROM doctor_info WHERE id = " + Search.Text + " ";
            SqlCommand cmd = new SqlCommand(query, Sqlobj);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not Deleted" + ex.Message);
            }
            finally
            {
                Sqlobj.Close();
                loadgrid();
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e) //Update Button
        {
            if (Sqlobj.State == ConnectionState.Closed)
                Sqlobj.Open();

            string query = "UPDATE doctor_info SET name = " + "'" + Name.Text + "',email = '" + Email.Text + "',password = '" + Password.Password+ "',phone = '" + 
                Phone.Text + "',fees = '" + Fees.Text + "',specialization = '" + Specialization.Text + "'" + "" + " WHERE id = '" + Search.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Sqlobj);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Sqlobj.Close();
                clear();
                loadgrid();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //Clear Button
        {
            clear();
            loadgrid();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) //sign out button
        {
            admin_login obj = new admin_login();
            obj.Show();
            this.Close();
        }
    }
}