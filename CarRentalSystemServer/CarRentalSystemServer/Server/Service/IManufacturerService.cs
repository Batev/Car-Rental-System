namespace Server.Service
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// An interface for the business logic (service) layer
    /// that connects the data access objects (DAOs) with the
    /// ASP.NET controllers.
    /// </summary>
    public interface IManufacturerService
    {
        /// <summary>
        /// Saves a new manufacturer.
        /// </summary>
        /// <param name="manufacturer">The new manufacturer to be saved.</param>
        void Insert(Manufacturer manufacturer);

        /// <summary>
        /// Updates a manufacturer.
        /// </summary>
        /// <param name="id">The id of the manufacturer to be updated.</param>
        /// <param name="manufacturer">The new attributes of the manufacturer.</param>
        void Update(int id, Manufacturer manufacturer);

        /// <summary>
        /// Gets all manufacturers.
        /// </summary>
        /// <returns>Collection of all manufacturers.</returns>
        ICollection<Manufacturer> GetAll();

        /// <summary>
        /// Gets a single manufacturer.
        /// </summary>
        /// <param name="id">The id of the searched manufacturer.</param>
        /// <returns>The searched manufacturer.</returns>
        Manufacturer Get(int id);

        /// <summary>
        /// Deletes a manufacturer.
        /// </summary>
        /// <param name="id">The id of the manufacturer to be deleted.</param>
        void Delete(int id);
    }
}