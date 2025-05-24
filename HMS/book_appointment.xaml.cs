using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HMS
{
    public partial class book_appointment : Window
    {
        int p_id;
        int doctorID;
        public book_appointment(int id)
        {
            InitializeComponent();
            p_id = id;
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");

        public void clear() //clear textboxes
        {
            Doctor.Clear();
            Date.Clear();
            Time.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //book button
        {
            try
            {
                Sqlobj.Open();

                // Extract doctor ID from doctor name textbox
                SqlCommand Cmd = new SqlCommand("SELECT id FROM doctor_info WHERE name = @doctorName", Sqlobj);
                Cmd.Parameters.AddWithValue("@doctorName", Doctor.Text);
                object result = Cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Doctor not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                doctorID = (int)result;

                // Insert appointment
                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO appointment_detail (patient_id, doctor_id, date, time) VALUES (@p_id, @doctorID, @date, @time)",
                    Sqlobj
                );
                insertCmd.Parameters.AddWithValue("@p_id", p_id);
                insertCmd.Parameters.AddWithValue("@doctorID", doctorID);
                insertCmd.Parameters.AddWithValue("@date", Date.Text);
                insertCmd.Parameters.AddWithValue("@time", Time.Text);

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

        public void loadgrid() //load data about appointment and doctor
        {
            //join query to load data from two tables
            string query = @"
                SELECT 
                    doctor_info.name, 
                    doctor_info.specialization, 
                    appointment_detail.date, 
                    appointment_detail.time 
                FROM 
                    doctor_info 
                INNER JOIN 
                    appointment_detail 
                ON 
                    doctor_info.id = appointment_detail.doctor_id 
                WHERE 
                    appointment_detail.patient_id = @p_id";

            SqlCommand cmd = new SqlCommand(query, Sqlobj);
            cmd.Parameters.AddWithValue("@p_id", p_id);

            DataTable dt = new DataTable();

            try
            {
                Sqlobj.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                datagrid.ItemsSource = dt.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Sqlobj.Close();
            }
        }

        public void loadgrid1() //load data about doctor from which appointments are booked
        {
            SqlCommand cmd = new SqlCommand("SELECT id,name,email,specialization,fees FROM doctor_info", Sqlobj);
            DataTable dt = new DataTable();
            Sqlobj.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Sqlobj.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e) // refresh button to call loadgrid
        {
            loadgrid1();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //home button
        {
            homepage_patient obj = new homepage_patient(p_id);
            obj.Show();
            this.Close();
        }
    }
}
