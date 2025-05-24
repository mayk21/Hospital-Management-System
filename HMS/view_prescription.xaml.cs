using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace HMS
{
    public partial class view_prescription : Window
    {
        int patientID;
        public view_prescription(int id)
        {
            InitializeComponent();
            patientID = id;
        }

        SqlConnection Sqlobj = new SqlConnection(@"Data Source=MALIK-ASFAND;Initial Catalog=""project"";Integrated Security=True");

        public void loadgrid() //load data about doctor and prescription
        {
            //join query to load data from different tables
            SqlCommand cmd = new SqlCommand("SELECT doctor_info.name, doctor_info.specialization, prescription_detail.medicine, prescription_detail.detail, prescription_detail.date FROM doctor_info INNER JOIN prescription_detail ON doctor_info.id = prescription_detail.doctor_id WHERE prescription_detail.patient_id = @patientID", Sqlobj);
            cmd.Parameters.AddWithValue("@patientID", patientID);
            DataTable dt = new DataTable();
            Sqlobj.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Sqlobj.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //refresh button to call loadgrid
        {
            loadgrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //home button
        {
            homepage_patient obj = new homepage_patient(patientID);
            obj.Show();
            this.Close();
        }
    }
}
