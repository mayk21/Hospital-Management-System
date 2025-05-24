using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HMS
{
    public partial class prescriptions : Window
    {
        int doctor_id;
        int patientID;
        public prescriptions(int doctor_id)
        {
            InitializeComponent();
            this.doctor_id = doctor_id;
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");

        public void clear() //method to clear textboxes
        {
            Patient.Clear();
            Medicine.Clear();
            Detail.Clear();
            Date.Clear();
        }

        public void loadgrid() //load data from patient and prescription table
        {
            // join query to load data from different tables
            SqlCommand cmd = new SqlCommand("SELECT patient_info.name, patient_info.age, prescription_detail.medicine, prescription_detail.detail, prescription_detail.date FROM patient_info INNER JOIN prescription_detail ON patient_info.id = prescription_detail.patient_id WHERE prescription_detail.patient_id = @patientID", Sqlobj);
            cmd.Parameters.AddWithValue("@patientID", patientID);
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

        private void Button_Click(object sender, RoutedEventArgs e) //prescribe button
        {
            try
            {
                Sqlobj.Open();
                //extracting patient id from patient name textbox
                SqlCommand Cmd = new SqlCommand("SELECT id FROM patient_info WHERE name = @patientName", Sqlobj);
                Cmd.Parameters.AddWithValue("@patientName", Patient.Text);

                object result = Cmd.ExecuteScalar(); //execute the query to get result

                if (result == null) 
                {
                    MessageBox.Show("Patient not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                patientID = (int)result; // Convert the result to int to get patient id

                //insert data in prescription table
                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO prescription_detail (patient_id, doctor_id, medicine, detail, date) VALUES (@patientID, @doctorID, @medicine, @detail, @date)",
                    Sqlobj
                );
                insertCmd.Parameters.AddWithValue("@patientID", patientID);
                insertCmd.Parameters.AddWithValue("@doctorID", doctor_id);
                insertCmd.Parameters.AddWithValue("@medicine", Medicine.Text);
                insertCmd.Parameters.AddWithValue("@detail", Detail.Text);
                insertCmd.Parameters.AddWithValue("@date", Date.Text);

                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Successfully added", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Sqlobj.Close();
                loadgrid();
                clear();
            }
        }


        private void Button_Click_4(object sender, RoutedEventArgs e) //Button to call loadgrid
        {
            loadgrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //home button
        {
            homepage_doctor obj = new homepage_doctor(doctor_id);
            obj.Show();
            this.Close();
        }
    }
}
