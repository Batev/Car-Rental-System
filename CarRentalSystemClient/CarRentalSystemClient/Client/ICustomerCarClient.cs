namespace Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    /// <summary>
    /// An interface for sending HTTP requests to the server
    /// for a certain object.
    /// </summary>
    public interface ICustomerCarClient
    {
        /// <summary>
        /// Sends a get request for all objects mapping car and customer.
        /// </summary>
        /// <returns>Enumeration of all objects mapping car and customer.</returns>
        Task<IEnumerable<CustomerCar>> GetAllCustomerCarsAsync();

        /// <summary>
        /// Sends a get request for a object mapping car and customer by its id.
        /// </summary>
        /// <param name="id">The id of the object mapping car and customer.</param>
        /// <returns>The searched object mapping car and customer.</returns>
        Task<CustomerCar> GetCustomerCarByIdAsync(int id);

        /// <summary>
        /// Sends a request to saves a new object mapping car and customer.
        /// </summary>
        /// <param name="customerCar">The new object mapping car and customer to be saved.</param>
        /// <returns>A task representing the current process.</returns>
        Task AddCustomerCarAsync(CustomerCar customerCar);

        /// <summary>
        /// Sends a request to update an already existing object mapping car and customer.
        /// </summary>
        /// <param name="id">The id of the object mapping car and customer to be updated.</param>
        /// <param name="customerCar">The new attributes of the object mapping car and customer.</param>
        /// <returns>A task representing the current process.</returns>
        Task UpdateCustomerCarAsync(int id, CustomerCar customerCar);

        /// <summary>
        /// Sends a request to delete an already existing object mapping car and customer.
        /// </summary>
        /// <param name="id">The id of the object mapping car and customer to be deleted.</param>
        /// <returns>A task representing the current process.</returns>
        Task DeleteCarAsync(int id);

        /// <summary>
        /// Sends a get request for all objects mapping car and customer by the customer id.
        /// </summary>
        /// <param name="id">The id of the costumer.</param>
        /// <returns>Enumeration of all cars rented by the costumer.</returns>
        Task<IEnumerable<RentedCar>> GetByCostumerIdAsync(int id);
    }
}