using System.Windows;

namespace InterfaceApplication
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {

        public AutorizationWindow()
        {

            InitializeComponent();

        }

        private void updateButton_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
