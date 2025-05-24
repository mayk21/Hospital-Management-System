using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace HMS
{
    public partial class admin_login : Window
    {
        public admin_login()
        {
            InitializeComponent();
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");
        private void Button_Click(object sender, RoutedEventArgs e) //login button
        {
            try
            {
                if (Sqlobj.State == ConnectionState.Closed)
                    Sqlobj.Open();

                String query = "SELECT COUNT(1) FROM admin WHERE username = @Username AND password = @Password";

                SqlCommand cmd = new SqlCommand(query, Sqlobj);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@username", Username.Text);
                cmd.Parameters.AddWithValue("@password", Password.Password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    homepage_admin obj = new homepage_admin();
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