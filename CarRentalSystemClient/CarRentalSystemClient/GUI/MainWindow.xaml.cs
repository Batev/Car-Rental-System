namespace GUI
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Client;
    using Client.Implementation;
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static bool IsLoggedOut { get; set; }

        private readonly ICarClient _carClient;
        private readonly IManufacturerClient _manufacturerClient;
        private readonly ICustomerCarClient _customerCarClient;

        public MainWindow()
        {
            _carClient = new CarClient();
            _manufacturerClient = new ManufacturerClient();
            _customerCarClient = new CustomerCarClient();

            InitializeComponent();

            FillSearchComboBox();
            Reset();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            PopUp popUp = new PopUp();
            popUp.ShowDialog();

            if (IsLoggedOut)
            {
                this.Hide();
                LogIn logIn = new LogIn();
                logIn.Show();
                this.Close();
            }
        }
        
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Object selectedItem = SearchComboBox.SelectedItem;

            if (selectedItem != null)
            {
                Manufacturer manufacturer = (Manufacturer)selectedItem;
                IEnumerable<Car> cars = Task.Run(() => _carClient.GetCarsByManufacturerAsync(manufacturer.Id)).Result;
                FillCarsForRentDataGrid(CarsForRentDataGrid, cars);
            }
            else
            {
                MessageBox.Show("Please select a model from the search menu.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void FillCarsForRentDataGrid(DataGrid carsForRentDataGrid, IEnumerable<Car> cars)
        {
            carsForRentDataGrid.Columns.Clear();
            carsForRentDataGrid.Items.Refresh();

            carsForRentDataGrid.ItemsSource = cars;
            carsForRentDataGrid.IsReadOnly = true;
            carsForRentDataGrid.SelectionMode = DataGridSelectionMode.Single;

            DataGridTextColumn idColumn = new DataGridTextColumn() { };
            idColumn.Binding = new Binding("Id");
            idColumn.Header = "Car ID";
            carsForRentDataGrid.Columns.Add(idColumn);

            DataGridTextColumn manufacturerColumn = new DataGridTextColumn() { };
            manufacturerColumn.Binding = new Binding("ManufacturerId");
            manufacturerColumn.Header = "Manufacturer";
            carsForRentDataGrid.Columns.Add(manufacturerColumn);

            DataGridTextColumn modelColumn = new DataGridTextColumn() { };
            modelColumn.Binding = new Binding("Model");
            modelColumn.Header = "Model";
            carsForRentDataGrid.Columns.Add(modelColumn);

            DataGridTextColumn priceColumn = new DataGridTextColumn() { };
            priceColumn.Binding = new Binding("Price");
            priceColumn.Header = "Price";
            carsForRentDataGrid.Columns.Add(priceColumn);
        }

        private void FillRentedCarsDataGrid(DataGrid rentedCarsDataGrid, IEnumerable<RentedCar> cars)
        {
            rentedCarsDataGrid.Columns.Clear();
            rentedCarsDataGrid.Items.Refresh();

            rentedCarsDataGrid.ItemsSource = cars;
            rentedCarsDataGrid.IsReadOnly = true;
            rentedCarsDataGrid.SelectionMode = DataGridSelectionMode.Single;

            DataGridTextColumn idColumn = new DataGridTextColumn() { };
            idColumn.Binding = new Binding("Id");
            idColumn.Header = "Reservation ID";
            rentedCarsDataGrid.Columns.Add(idColumn);

            DataGridTextColumn manufacturerColumn = new DataGridTextColumn() { };
            manufacturerColumn.Binding = new Binding("Manufacturer");
            manufacturerColumn.Header = "Manufacturer";
            rentedCarsDataGrid.Columns.Add(manufacturerColumn);

            DataGridTextColumn modelColumn = new DataGridTextColumn() { };
            modelColumn.Binding = new Binding("Model");
            modelColumn.Header = "Model";
            rentedCarsDataGrid.Columns.Add(modelColumn);

            DataGridTextColumn priceColumn = new DataGridTextColumn() { };
            priceColumn.Binding = new Binding("Price");
            priceColumn.Header = "Price";
            rentedCarsDataGrid.Columns.Add(priceColumn);

            DataGridTextColumn rentedOnColumn = new DataGridTextColumn() { };
            rentedOnColumn.Binding = new Binding("RentedOn");
            rentedOnColumn.Header = "Rented on:";
            rentedCarsDataGrid.Columns.Add(rentedOnColumn);

            DataGridTextColumn returnedOn = new DataGridTextColumn() { };
            returnedOn.Binding = new Binding("ReturnedOn");
            returnedOn.Header = "Returned on:";
            rentedCarsDataGrid.Columns.Add(returnedOn);
        }

        private void FillSearchComboBox()
        {
            IEnumerable<Manufacturer> manufacturers = Task.Run(() => _manufacturerClient.GetAllManufacturersAsync()).Result;

            foreach (Manufacturer manufacturer in manufacturers)
            {
                SearchComboBox.Items.Add(manufacturer);
            }
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car)CarsForRentDataGrid.SelectedItem;

            if (car != null)
            {
                CustomerCar customerCar = new CustomerCar()
                {
                    CarId = car.Id,
                    CustomerId = App.LoggedUserId
                };

                Task.Run(() => _customerCarClient.AddCustomerCarAsync(customerCar)).Wait();

                MessageBox.Show(string.Format("{0} {1} rented successfully.", car.ManufacturerId, car.Model), "Rent", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                Reset();
            }

            else
            {
                MessageBox.Show("Please select a car from the menu.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Reset()
        {
            FillCarsForRentDataGrid(CarsForRentDataGrid, Task.Run(() => _carClient.GetAllCarsAsync()).Result);
            FillRentedCarsDataGrid(RentedCarsDataGrid, Task.Run(() => _customerCarClient.GetByCostumerIdAsync(App.LoggedUserId)).Result);
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            RentedCar rentedCar = (RentedCar)RentedCarsDataGrid.SelectedItem;

            if (rentedCar != null)
            {
                if (rentedCar.ReturnedOn == null)
                {
                    CustomerCar customerCar = new CustomerCar()
                    {
                        Id = rentedCar.Id,
                        CarId = rentedCar.CarId,
                        RentedOn = rentedCar.RentedOn,
                        ReturnedOn = rentedCar.ReturnedOn
                    };

                    Task.Run(() => _customerCarClient.UpdateCustomerCarAsync(rentedCar.Id, customerCar)).Wait();

                    decimal price = ((DateTime.Now - rentedCar.RentedOn).Days + 1) * rentedCar.Price;

                    MessageBox.Show(string.Format("You have to pay {0} € for the rent.", price), "Invoice",
                        MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);

                    Reset();
                }
                else
                {
                    MessageBox.Show("Car already returned.", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a car from the menu.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
