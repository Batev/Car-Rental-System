namespace GUI
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {
        public PopUp()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.IsLoggedOut = true;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.IsLoggedOut = false;
            this.Close();
        }
    }
}