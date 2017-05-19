namespace GUI
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using Client;
    using Client.Implementation;
    using Model;

    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private readonly ICustomerClient _customerClient;

        public LogIn()
        {
            _customerClient = new CustomerClient();

            InitializeComponent();
        }
        
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextbox.Text;
            string password = PasswordBox.Password;

            if (String.IsNullOrWhiteSpace(username) ||
                String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username field and password field must not be empty.", "Log In Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                int id = Task.Run(() => _customerClient.AddCustomerAsync(new Customer()
                {
                    Id = -1,
                    Username = username,
                    Password = password,
                    FirstName = "",
                    LastName = "",
                    IsDeleted = false
                })).Result;

                if (id == -1)
                {
                    MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    
                }
                else
                {
                    App.LoggedUserId = id;
                    this.Hide();
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
            this.Show();
        }
    }
}
