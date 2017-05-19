namespace Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    /// <summary>
    /// An interface for sending HTTP requests to the server
    /// for a certain object.
    /// </summary>
    public interface ICarClient
    {
        /// <summary>
        /// Sends a get request for all available cars.
        /// </summary>
        /// <returns>Enumeration of all cars.</returns>
        Task<IEnumerable<Car>> GetAllCarsAsync();

        /// <summary>
        /// Sends a get request for a car by its id.
        /// </summary>
        /// <param name="id">The id of the car.</param>
        /// <returns>The searched car.</returns>
        Task<Car> GetCarByIdAsync(int id);

        /// <summary>
        /// Sends a request to save a new car.
        /// </summary>
        /// <param name="car">The new car to be saved.</param>
        /// <returns>A task representing the current process.</returns>
        Task AddCarAsync(Car car);

        /// <summary>
        /// Sends a request to update an already existing car.
        /// </summary>
        /// <param name="id">The id of the car to be updated.</param>
        /// <param name="car">The new attributes of the car.</param>
        /// <returns>A task representing the current process.</returns>
        Task UpdateCarAsync(int id, Car car);

        /// <summary>
        /// Sends a request to delete an already existing car.
        /// </summary>
        /// <param name="id">The id of the car to be deleted.</param>
        /// <returns>A task representing the current process.</returns>
        Task DeleteCarAsync(int id);

        /// <summary>
        /// Sends a request to get all cars by their manufacturer.
        /// </summary>
        /// <param name="manufacturerId">The id of the manufacturer.</param>
        /// <returns>A task representing the current process.</returns>
        Task<IEnumerable<Car>> GetCarsByManufacturerAsync(int manufacturerId);
    }
}