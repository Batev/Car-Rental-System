namespace Server.Persistence
{
    using System.Collections.Generic;
    using Server.Models;

    /// <summary>
    /// An interface for a mapping data access object.
    /// </summary>
    public interface IManufacturerPersistence
    {
        /// <summary>
        /// Saves a new manufacturer to the database.
        /// </summary>
        /// <param name="manufacturer">The new manufacturer to be saved.</param>
        void Insert(Manufacturer manufacturer);

        /// <summary>
        /// Updates the attributes of an already existing manufacturer 
        /// in the database.
        /// </summary>
        /// <param name="id">The id of the manufacturer to be updated.</param>
        /// <param name="manufacturer">The new attributes to the manufacturer.</param>
        void Update(int id, Manufacturer manufacturer);

        /// <summary>
        /// Deletes a certain manufacturer from the database.
        /// </summary>
        /// <param name="id">The id of the manufacturer to be deleted.</param>
        void Delete(int id);

        /// <summary>
        /// Gets a manufacturer from the database.
        /// </summary>
        /// <param name="id">The id of the manufacturer.</param>
        /// <returns>The searched manufacturer.</returns>
        Manufacturer Get(int id);

        /// <summary>
        /// Gets all manufacturers from the database.
        /// </summary>
        /// <returns>Collection of all manufacturers.</returns>
        ICollection<Manufacturer> GetAll();
    }
}