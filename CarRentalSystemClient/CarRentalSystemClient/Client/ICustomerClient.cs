namespace Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    /// <summary>
    /// An interface for sending HTTP requests to the server
    /// for a certain object.
    /// </summary>
    public interface ICustomerClient
    {

        /// <summary>
        /// Sends a get request for all customers.
        /// </summary>
        /// <returns>Enumeration of all customers.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Sends a get request for a customer by its id.
        /// </summary>
        /// <param name="id">The id of the customer.</param>
        /// <returns>The searched customer.</returns>
        Task<Customer> GetCustomerByIdAsync(int id);

        /// <summary>
        /// Sends a request to save a new customer.
        /// </summary>
        /// <param name="customer">The new customer to be saved.</param>
        /// <returns>A task representing the current process.</returns>
        Task<int> AddCustomerAsync(Customer customer);

        /// <summary>
        /// Sends a request to update an already existing customer.
        /// </summary>
        /// <param name="id">The id of the customer to be updated.</param>
        /// <param name="customer">The new attributes of the customer.</param>
        /// <returns>A task representing the current process.</returns>
        Task UpdateCustomerAsync(int id, Customer customer);

        /// <summary>
        /// Sends a request to delete an already existing customer.
        /// </summary>
        /// <param name="id">The id of the customer to be deleted.</param>
        /// <returns>A task representing the current process.</returns>
        Task DeleteCustomerAsync(int id);
    }
}