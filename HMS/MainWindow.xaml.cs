using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace HMS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=project;Integrated Security=True");

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int patientID = -1; 
            try
            {
                if (Sqlobj.State == ConnectionState.Closed)
                    Sqlobj.Open();

                string query = "SELECT COUNT(1) FROM patient_info WHERE email = @Email AND password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, Sqlobj))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Email", Email.Text); 
                    cmd.Parameters.AddWithValue("@Password", SecureData.HashString(Password.Password)); 

                    int count = Convert.ToInt32(cmd.ExecuteScalar()); // Execute query and get the count

                    if (count == 1) // If user exists
                    {
                        // Retrieve the patient ID
                        string query1 = "SELECT id FROM patient_info WHERE email = @Email AND password = @Password";
                        using (SqlCommand command = new SqlCommand(query1, Sqlobj))
                        {
                            command.Parameters.AddWithValue("@Email", Email.Text); 
                            command.Parameters.AddWithValue("@Password", SecureData.HashString(Password.Password)); 

                            object result = command.ExecuteScalar(); // Execute query to get patient ID
                            if (result != null)
                            {
                                patientID = Convert.ToInt32(result); // Convert result to integer
                            }
                        }

                        homepage_patient obj = new homepage_patient(patientID);
                        obj.Show(); 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Username or Password are incorrect"); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
            finally
            {
                Sqlobj.Close(); 
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            signup obj = new signup(); 
            obj.Show(); 
            this.Close(); 
        }

        
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            homepage obj = new homepage(); 
            obj.Show(); 
            this.Close();
        }
    }
}
