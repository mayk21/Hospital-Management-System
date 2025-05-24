using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace HMS
{
    public partial class view_appointments : Window
    {
        int doctorID;
        public view_appointments(int doctorID)
        {
            InitializeComponent();
            this.doctorID = doctorID;
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");

        public void loadgrid() //loading patient and appointment data
        {
           //join query to load data from different tables
            SqlCommand cmd = new SqlCommand("SELECT patient_info.name, appointment_detail.date, appointment_detail.time FROM patient_info INNER JOIN appointment_detail ON patient_info.id = appointment_detail.patient_id WHERE appointment_detail.doctor_id = @doctorID", Sqlobj);
            cmd.Parameters.AddWithValue("@doctorID", doctorID); 
            DataTable dt = new DataTable();
            try
            {
                Sqlobj.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Sqlobj.Close();
            }
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //refresh button to call loadgrid
        {
            loadgrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //home button
        {
            homepage_doctor obj = new homepage_doctor(doctorID);
            obj.Show();
            this.Close();
        }
    }
}
