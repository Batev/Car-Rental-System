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
    public class CustomerController : ApiController
    {
        /// <summary>
        /// <see cref="ICustomerService"/> object for forwarding requests and responses.
        /// </summary>
        private readonly ICustomerService _customerService = new CustomerService();

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/Customer
        /// </summary>
        /// <returns>Enumeration of all customers.</returns>
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetAll();
        }

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/Customer/5
        /// </summary>
        /// <param name="id">The id of the searched customer.</param>
        /// <returns>The searched customer.</returns>
        public Customer Get(int id)
        {
            return _customerService.Get(id);
        }

        /// <summary>
        /// Executes a save request from a client.
        /// POST: api/Customer
        /// </summary>
        /// <param name="customer">The new customer to be saved.</param>
        /// <returns>The id of the saved customer if authentication required, -1 otherwise.</returns>
        public int Post([FromBody]Customer customer)
        {
            return _customerService.Insert(customer);
        }

        /// <summary>
        /// Executes an update request from a client.
        /// PUT: api/Customer/5
        /// </summary>
        /// <param name="id">The id of the customer to be updated.</param>
        /// <param name="customer">The customer with new attributes.</param>
        public void Put(int id, [FromBody]Customer customer)
        {
            _customerService.Update(id, customer);
        }

        /// <summary>
        /// Executes a delete request from a client.
        /// DELETE: api/Customer/5
        /// </summary>
        /// <param name="id">The id of the customer to be deleted.</param>
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}
