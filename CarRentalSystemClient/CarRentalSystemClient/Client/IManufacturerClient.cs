namespace Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    /// <summary>
    /// An interface for sending HTTP requests to the server
    /// for a certain object.
    /// </summary>
    public interface IManufacturerClient
    {
        /// <summary>
        /// Sends a get request for all available manufacturers.
        /// </summary>
        /// <returns>Enumeration of all manufacturers.</returns>
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();

        /// <summary>
        /// Sends a get request for a manufacturer by its id.
        /// </summary>
        /// <param name="id">The id of the manufacturer.</param>
        /// <returns>The searched manufacturer.</returns>
        Task<Manufacturer> GetManufacturerByIdAsync(int id);

        /// <summary>
        /// Sends a request to save a new manufacturer.
        /// </summary>
        /// <param name="manufacturer">The new manufacturer to be saved.</param>
        /// <returns>A task representing the current process.</returns>
        Task AddManufacturerAsync(Manufacturer manufacturer);

        /// <summary>
        /// Sends a request to update an already existing manufacturer.
        /// </summary>
        /// <param name="id">The id of the manufacturer to be updated.</param>
        /// <param name="manufacturer">The new attributes of the manufacturer.</param>
        /// <returns>A task representing the current process.</returns>
        Task UpdateManufacturerAsync(int id, Manufacturer manufacturer);

        /// <summary>
        /// Sends a request to delete an already existing manufacturer.
        /// </summary>
        /// <param name="id">The id of the manufacturer to be deleted.</param>
        /// <returns>A task representing the current process.</returns>
        Task DeleteManufacturerAsync(int id);
    }
}