namespace Server.Service
{
    using System.Collections.Generic;
    using Server.Models;

    /// <summary>
    /// An interface for the business logic (service) layer
    /// that connects the data access objects (DAOs) with the
    /// ASP.NET controllers.
    /// </summary>
    public interface ICustomerCarService
    {
        /// <summary>
        /// Saves a new object of the mapping  
        /// between customer and car.
        /// </summary>
        /// <param name="customerCar">The new object to be saved.</param>
        void Insert(CustomerCar customerCar);

        /// <summary>
        /// Updates an object of the mapping 
        /// between customer and car.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        /// <param name="customerCar">The new attributes of the object.</param>
        void Update(int id, CustomerCar customerCar);

        /// <summary>
        /// Gets all objects of the mapping 
        /// between customer and car.
        /// </summary>
        /// <returns>Enumeration of all objects.</returns>
        IEnumerable<CustomerCar> GetAll();

        /// <summary>
        /// Gets a single object of the mapping 
        /// between customer and car.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        /// <returns>The searched object.</returns>
        CustomerCar Get(int id);

        /// <summary>
        /// Deletes a object of the table 
        /// between customer and car.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        void Delete(int id);

        /// <summary>
        /// Gets objects of the mapping 
        /// between customer and car for a certain customer.
        /// </summary>
        /// <param name="id">The id of the customer.</param>
        /// <returns>Enumeration of all object by customer id.</returns>
        IEnumerable<RentedCar> GetByCustomerId(int id);
    }
}