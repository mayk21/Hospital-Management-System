using System.Windows;

namespace HMS
{
    public partial class homepage_doctor : Window
    {
        int doctor_id;
        public homepage_doctor(int doctor_id) 
        {
            InitializeComponent();
            this.doctor_id = doctor_id;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //view appointment button
        {
            view_appointments obj = new view_appointments(doctor_id);
            obj.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //write prescription button
        {
            prescriptions obj = new prescriptions(doctor_id);
            obj.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //signout button
        {
            doctor_login obj = new doctor_login();
            obj.Show();
            this.Close();
        }
    }
}
