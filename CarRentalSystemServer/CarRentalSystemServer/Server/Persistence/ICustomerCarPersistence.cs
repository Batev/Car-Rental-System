namespace Server.Persistence
{
    using System.Collections.Generic;
    using Server.Models;

    /// <summary>
    /// An interface for a mapping data access object.
    /// </summary>
    public interface ICustomerCarPersistence
    {
        /// <summary>
        /// Saves a new object of the mapping table 
        /// between customer and car.
        /// </summary>
        /// <param name="customerCar">The new object to be saved.</param>
        void Insert(CustomerCar customerCar);

        /// <summary>
        /// Updates an object of the mapping table 
        /// between customer and car.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        /// <param name="customerCar">The new attributes of the object.</param>
        void Update(int id, CustomerCar customerCar);

        /// <summary>
        /// Gets all objects of the mapping table 
        /// between customer and car.
        /// </summary>
        /// <returns>List of all objects.</returns>
        IEnumerable<CustomerCar> GetAll();

        /// <summary>
        /// Gets a single object of the mapping table 
        /// between customer and car.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        /// <returns>The searched object.</returns>
        CustomerCar Get(int id);

        /// <summary>
        /// Deletes a object of the mapping table 
        /// between customer and car.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        void Delete(int id);

        /// <summary>
        /// Gets objects of the mapping table 
        /// between customer and car for a certain customer.
        /// </summary>
        /// <param name="id">The id of the customer.</param>
        /// <returns>List of all object by customer id.</returns>
        IEnumerable<RentedCar> GetByCustomerId(int id);
    }
}