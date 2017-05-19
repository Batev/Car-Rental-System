namespace Server.Service
{
    using System.Collections.Generic;
    using Server.Models;
    
    /// <summary>
    /// An interface for the business logic (service) layer
    /// that connects the data access objects (DAOs) with the
    /// ASP.NET controllers.
    /// </summary>
    public interface ICarService
    {
        /// <summary>
        /// Saves a new car.
        /// </summary>
        /// <param name="car">The new car to be saved.</param>
        void Insert(Car car);

        /// <summary>
        /// Updates a car.
        /// </summary>
        /// <param name="id">The id of the car to be updated.</param>
        /// <param name="car">The new attributes of the car.</param>
        void Update(int id, Car car);

        /// <summary>
        /// Gets all cars.
        /// </summary>
        /// <returns>Collection of all cars.</returns>
        ICollection<Car> GetAll();

        /// <summary>
        /// Gets a single car.
        /// </summary>
        /// <param name="id">The id of the searched car.</param>
        /// <returns>The searched car.</returns>
        Car Get(int id);

        /// <summary>
        /// Deletes a car.
        /// </summary>
        /// <param name="id">The id of the car to be deleted.</param>
        void Delete(int id);

        /// <summary>
        /// Gets a collection of cars by their 
        /// respective manufacturer.
        /// </summary>
        /// <param name="id">The id of the manufacturer of the cars.</param>
        /// <returns>Collection of all cars by manufacturer.</returns>
        ICollection<Car> GetCarsByManufacturerId(int id);
    }
}