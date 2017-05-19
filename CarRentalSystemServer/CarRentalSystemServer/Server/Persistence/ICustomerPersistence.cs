namespace Server.Persistence
{
    using System.Collections.Generic;
    using Server.Models;

    /// <summary>
    /// An interface for a mapping data access object.
    /// </summary>
    public interface ICustomerPersistence
    {
        /// <summary>
        /// Authenticates an user/customer credentials.
        /// </summary>
        /// <param name="customer">The user/customer to be authenticated.</param>
        /// <returns>The id of the authenticated user/customer. -1 if no such a user/customer exists.</returns>
        int Authenticate(Customer customer);

        /// <summary>
        /// Saves a new customer to the database.
        /// </summary>
        /// <param name="customer">The new customer to be saved.</param>
        int Insert(Customer customer);

        /// <summary>
        /// Updates a user in the database.
        /// </summary>
        /// <param name="id">The id of the customer to be updated.</param>
        /// <param name="customer">The new attributes of the customer.</param>
        void Update(int id, Customer customer);

        /// <summary>
        /// Gets all customers from the database.
        /// </summary>
        /// <returns>List of all customers.</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Gets a single customer from the database.
        /// </summary>
        /// <param name="id">The id of the searched customer.</param>
        /// <returns>The searched customer.</returns>
        Customer Get(int id);

        /// <summary>
        /// Deletes a customer from the database.
        /// </summary>
        /// <param name="id">The id of the customer to be deleted.</param>
        void Delete(int id);
    }
}