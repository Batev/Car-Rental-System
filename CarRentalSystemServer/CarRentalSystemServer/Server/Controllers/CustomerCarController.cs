namespace Server.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Service;
    using Service.Implementation;
    using Server.Models;

    /// <summary>
    /// Class that takes care of the requests and responses 
    /// send to and by the server.
    /// </summary>
    public class CustomerCarController : ApiController
    {
        /// <summary>
        /// <see cref="ICustomerCarService"/> object for forwarding requests and responses.
        /// </summary>
        private readonly ICustomerCarService _customerCar = new CustomerCarService();

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/CustomerCar
        /// </summary>
        /// <returns>Enumeration of all objects mapping customer and car.</returns>
        public IEnumerable<CustomerCar> Get()
        {
            return _customerCar.GetAll();
        }

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/CustomerCar/5
        /// </summary>
        /// <param name="id">The id of a customer.</param>
        /// <returns>Enumeration of all cars rented by a customer.</returns>
        public IEnumerable<RentedCar> Get(int id)
        {
            return _customerCar.GetByCustomerId(id);
        }

        /// <summary>
        /// Executes a save request from a client.
        /// POST: api/CustomerCar
        /// </summary>
        /// <param name="customerCar">The new object mapping customer and car to be saved.</param>
        public void Post([FromBody]CustomerCar customerCar)
        {
            _customerCar.Insert(customerCar);
        }

        /// <summary>
        /// Executes a update request from a client.
        /// PUT: api/CustomerCar/5
        /// </summary>
        /// <param name="id">The id of the object mapping customer and car to be updated.</param>
        /// <param name="customerCar">The object mapping customer and car with new attributes.</param>
        public void Put(int id, [FromBody]CustomerCar customerCar)
        {
            _customerCar.Update(id, customerCar);
        }

        /// <summary>
        /// Executes a delete request from a client.
        /// DELETE: api/CustomerCar/5
        /// </summary>
        /// <param name="id">The id of the object mapping customer and car to be deleted.</param>
        public void Delete(int id)
        {
            _customerCar.Delete(id);
        }
    }
}
