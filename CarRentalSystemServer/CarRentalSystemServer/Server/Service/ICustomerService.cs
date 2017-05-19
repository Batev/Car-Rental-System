namespace Server.Service
{
    using System.Collections.Generic;
    using Server.Models;

    /// <summary>
    /// An interface for the business logic (service) layer
    /// that connects the data access objects (DAOs) with the
    /// ASP.NET controllers.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Saves a new customer.
        /// </summary>
        /// <param name="customer">The new customer to be saved.</param>
        /// <returns>The id of the new user, -1 on error.</returns>
        int Insert(Customer customer);

        /// <summary>
        /// Updates a customer.
        /// </summary>
        /// <param name="id">The id of the customer to be updated.</param>
        /// <param name="customer">The new attributes of the customer.</param>
        void Update(int id, Customer customer);

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>Enumeration of all customers.</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Gets a single customer.
        /// </summary>
        /// <param name="id">The id of the searched customer.</param>
        /// <returns>The searched customer.</returns>
        Customer Get(int id);

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        /// <param name="id">The id of the customer to be deleted.</param>
        void Delete(int id);
    }
}