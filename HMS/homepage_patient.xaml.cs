using System.Windows;

namespace HMS
{

    public partial class homepage_patient : Window
    {
        int id;
        public homepage_patient(int patientID)
        {
            InitializeComponent();
            id = patientID;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //update information button
        {
            update_information obj = new update_information(id);
            obj.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //book appointment butoon
        {
            book_appointment obj = new book_appointment(id);
            obj.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //view prescription button
        {
            view_prescription obj = new view_prescription(id);
            obj.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //signout button
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Close();
        }
    }
}
