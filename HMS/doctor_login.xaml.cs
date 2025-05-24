using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace HMS
{
    public partial class doctor_login : Window
    {
        public doctor_login()
        {
            InitializeComponent();
        }
        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");
        private void Button_Click(object sender, RoutedEventArgs e) //login button
        {
            int doctor_id = -1;
            try
            {
                if (Sqlobj.State == ConnectionState.Closed)
                    Sqlobj.Open();

                String query = "SELECT COUNT(1) FROM doctor_info WHERE email = @Email AND password = @Password";

                SqlCommand cmd = new SqlCommand(query, Sqlobj);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@email", Email.Text);
                cmd.Parameters.AddWithValue("@password", SecureData.HashString(Password.Password));

                int count = Convert.ToInt32(cmd.ExecuteScalar()); // Execute query and get the count

                if (count == 1) // If user exists
                {
                    // Retrieve the doctor ID
                    string query1 = "SELECT id FROM doctor_info WHERE email = @Email AND password = @Password";
                    using (SqlCommand command = new SqlCommand(query1, Sqlobj))
                    {
                        command.Parameters.AddWithValue("@email", Email.Text);
                        command.Parameters.AddWithValue("@password", SecureData.HashString(Password.Password));

                        object result = command.ExecuteScalar();// Execute query to get doctor ID
                        if (result != null)
                        {
                            doctor_id = Convert.ToInt32(result);//convert result to int
                        }
                    }

                    //going to homepage
                    homepage_doctor obj = new homepage_doctor(doctor_id);
                    obj.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Username or Password are incorrect");
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

        private void Button_Click_1(object sender, RoutedEventArgs e) //home button
        {
            homepage obj = new homepage();
            obj.Show();
            this.Close();
        }
    }
}
