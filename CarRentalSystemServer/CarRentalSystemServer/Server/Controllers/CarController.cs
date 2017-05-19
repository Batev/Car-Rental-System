namespace Server.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Server.Service;
    using Server.Service.Implementation;
    using Server.Models;

    /// <summary>
    /// Class that takes care of the requests and responses 
    /// send to and by the server.
    /// </summary>
    public class CarController : ApiController
    {
        /// <summary>
        /// <see cref="ICarService"/> object for forwarding requests and responses.
        /// </summary>
        private readonly ICarService _carService = new CarService();

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/Car
        /// </summary>
        /// <returns>Enumeration of all cars.</returns>
        public IEnumerable<Car> Get()
        {
            return _carService.GetAll();
        }

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/Car/5
        /// </summary>
        /// <param name="id">The id of the manufacturer of the car.</param>
        /// <returns>Enumeration of all cars with a certain manufacturer.</returns>
        public IEnumerable<Car> Get(int id)
        {
            return _carService.GetCarsByManufacturerId(id);
        }

        /// <summary>
        /// Executes a save request from a client.
        /// POST: api/Car
        /// </summary>
        /// <param name="car">The new car to be saved.</param>
        public void Post([FromBody]Car car)
        {
            _carService.Insert(car);
        }

        /// <summary>
        /// Executes an update request from a client.
        /// PUT: api/Car/5
        /// </summary>
        /// <param name="id">The id of the car to be updated.</param>
        /// <param name="car">The car with new attributes.</param>
        public void Put(int id, [FromBody]Car car)
        {
            _carService.Update(id, car);
        }

        /// <summary>
        /// Executes a delete request from a client.
        /// DELETE: api/Car/5
        /// </summary>
        /// <param name="id">The id of the car to be deleted.</param>
        public void Delete(int id)
        {
            _carService.Delete(id);
        }
    }
}
