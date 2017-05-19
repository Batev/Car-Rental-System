namespace GUI
{
    using System.Threading.Tasks;
    using System.Windows;
    using Client.Implementation;
    using Model;

    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private readonly CustomerClient _customerClient;

        public Register()
        {
            this._customerClient = new CustomerClient();

            InitializeComponent();
        }

        public void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer()
            {
                Id = 0,
                FirstName = FirstNameTextbox.Text,
                LastName = LastNameTextbox.Text,
                Username = UsernameTextbox.Text,
                Password = PasswordTextbox.Password,
                IsDeleted = false
            };

            bool isInputInvalid = (
                   string.IsNullOrWhiteSpace(customer.FirstName)
                || string.IsNullOrWhiteSpace(customer.LastName) 
                || string.IsNullOrWhiteSpace(customer.Username)
                || string.IsNullOrWhiteSpace(customer.Password));

            if (!isInputInvalid)
            {
                int id = Task.Run(() => _customerClient.AddCustomerAsync(customer)).Result;

                if (id != -1)
                {
                    MessageBox.Show("Customer registered successfully.", "Register Success", MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username already taken. Please try another one.", "Register Failure", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("All fields marked with (*) must not be empty.", "Register Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}