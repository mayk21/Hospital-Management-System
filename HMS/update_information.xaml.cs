using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace HMS
{
    public partial class update_information : Window
    {
        int pID;
        public update_information(int pID)
        {
            InitializeComponent();
            this.pID = pID;
        }
        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");
        DataSet ds = new DataSet();

        public void clear() //method to clear textboxes
        {
            Name.Clear();
            Email.Clear();
            Password.Clear();
            Phone.Clear();
            Age.Clear();
            Gender.Clear();
            Search.Clear();
        }

        public void loadgrid()//load data from patient information table
        {
            SqlCommand cmd = new SqlCommand("SELECT id, name,email,phone,age,gender FROM patient_info WHERE id = @pID", Sqlobj);
            cmd.Parameters.AddWithValue("@pID", pID);
            DataTable dt = new DataTable();
            Sqlobj.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Sqlobj.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool validation()
        {
            //checking for empty or blank spaces
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
            else if (String.IsNullOrEmpty(Age.Text) || String.IsNullOrWhiteSpace(Age.Text))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            else if (String.IsNullOrEmpty(Gender.Text) || String.IsNullOrWhiteSpace(Gender.Text))
            {
                MessageBox.Show("Please Enter the Valid Data", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            //regex for email format
            else if (!Regex.Match(Email.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").Success)
            {
                MessageBox.Show("Enter Valid Email address", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return false;
            }
            return true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e) //Update Button
        {
            if (Sqlobj.State == ConnectionState.Closed)
                Sqlobj.Open();

            string query = "UPDATE patient_info SET name = @Name, email = @Email, password = @Password, phone = @Phone, age = @Age, gender = @Gender WHERE id = @Id";
            SqlCommand cmd = new SqlCommand(query, Sqlobj);
            try
            {
                cmd.Parameters.AddWithValue("@Name", Name.Text);
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Password", SecureData.HashString(Password.Password));
                cmd.Parameters.AddWithValue("@Phone", Phone.Text);
                cmd.Parameters.AddWithValue("@Age", Age.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender.Text);
                cmd.Parameters.AddWithValue("@Id", Search.Text);

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

        private void Button_Click_1(object sender, RoutedEventArgs e) //home button
        {
            homepage_patient obj = new homepage_patient(pID);
            obj.Show();
            this.Close();
        }
    }
}
