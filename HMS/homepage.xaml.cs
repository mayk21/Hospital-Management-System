using System.Windows;

namespace HMS
{
    public partial class homepage : Window
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            doctor_login obj = new doctor_login();
            obj.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            admin_login obj = new admin_login();
            obj.Show();
            this.Close();
        }
    }
}
