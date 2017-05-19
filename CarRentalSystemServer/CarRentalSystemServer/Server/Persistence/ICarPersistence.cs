namespace Server.Persistence
{
    using System.Collections.Generic;
    using Server.Models;

    /// <summary>
    /// An interface for a mapping data access object.
    /// </summary>
    public interface ICarPersistence
    {
        /// <summary>
        /// Saves a new car to the database.
        /// </summary>
        /// <param name="car">The new car to be saved.</param>
        void Insert(Car car);

        /// <summary>
        /// Updates a car in the database.
        /// </summary>
        /// <param name="id">The id of the car to be updated.</param>
        /// <param name="car">The new attributes of the car.</param>
        void Update(int id, Car car);

        /// <summary>
        /// Gets all cars from the database.
        /// </summary>
        /// <returns>List of all cars.</returns>
        ICollection<Car> GetAll();

        /// <summary>
        /// Gets a single car from the database.
        /// </summary>
        /// <param name="id">The id of the searched car.</param>
        /// <returns>The searched car.</returns>
        Car Get(int id);

        /// <summary>
        /// Deletes a car from the database.
        /// </summary>
        /// <param name="id">The id of the car to be deleted.</param>
        void Delete(int id);

        /// <summary>
        /// Gets cars by their manufacturer.
        /// </summary>
        /// <param name="manufacturerId">The id of the manufacturer of the cars.</param>
        /// <returns>A collection of the cars.</returns>
        ICollection<Car> Search(int manufacturerId);
    }
}