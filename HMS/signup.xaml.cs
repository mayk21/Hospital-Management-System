using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace HMS
{
    public partial class signup : Window
    {
        public signup()
        {
            InitializeComponent();
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");
        DataSet ds = new DataSet();

        //Method to validate the input fields
        public bool validation()
        {
            //Check if any field is empty or contains only whitespace
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
            else if (String.IsNullOrEmpty(Phone.Text) || String.IsNullOrWhiteSpace(Phone.Text))
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
            // Validate email format using regular expressions
            else if (!Regex.Match(Email.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").Success)
            {
                MessageBox.Show("Enter Valid Email address", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            return true;
        }


        // Method to clear all input fields
        public void clear()
        {
            Name.Clear();
            Email.Clear();
            Phone.Clear();
            Password.Clear();
            Age.Clear();
            Gender.Clear();
            cbAgree.IsChecked = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbAgree.IsChecked == true)
                {
                    // Validate input before proceeding
                    if (validation())
                    {
                        // Check if email already exists
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM patient_info WHERE email = '" + Email.Text + "'", Sqlobj);
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        da.Fill(ds);
                        int i = ds.Tables[0].Rows.Count;
                        if (i > 0)
                        {
                            MessageBox.Show("Email: " + Email.Text + " already exist");
                            ds.Clear();
                            clear();
                        }
                        else
                        {
                            // Insert new patient information into the database
                            SqlCommand cmd = new SqlCommand("INSERT INTO patient_info VALUES (@name,@email,@password,@phone,@age,@gender)", Sqlobj);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@name", Name.Text);
                            cmd.Parameters.AddWithValue("@email", Email.Text);
                            cmd.Parameters.AddWithValue("@password", SecureData.HashString(Password.Password));// Hash password for security
                            cmd.Parameters.AddWithValue("@phone", Phone.Text);
                            cmd.Parameters.AddWithValue("@age", Age.Text);
                            cmd.Parameters.AddWithValue("@gender", Gender.Text);

                            Sqlobj.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Successfully added", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                            clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Agree terms and Conditions before signup");
                    clear();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Sqlobj.Close();
                clear();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //login button
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //clear button
        {
            clear();
        }
    }
}