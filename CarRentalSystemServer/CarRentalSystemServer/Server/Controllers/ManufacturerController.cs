namespace Server.Controllers
{
    using Server.Models;
    using System.Collections.Generic;
    using System.Web.Http;
    using Service;
    using Service.Implementation;

    /// <summary>
    /// Class that takes care of the requests and responses 
    /// send to and by the server.
    /// </summary>
    public class ManufacturerController : ApiController
    {
        /// <summary>
        /// <see cref="IManufacturerService"/> object for forwarding requests and responses.
        /// </summary>
        private readonly IManufacturerService _manufacturerService = new ManufacturerService();

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/Manufacturer
        /// </summary>
        /// <returns>Enumeration of all manufacturers.</returns>
        public IEnumerable<Manufacturer> Get()
        {
            return _manufacturerService.GetAll();
        }

        /// <summary>
        /// Executes a get request from a client.
        /// GET: api/Manufacturer/5
        /// </summary>
        /// <param name="id">The id of the searched manufacturer.</param>
        /// <returns>The searched manufacturer.</returns>
        public Manufacturer Get(int id)
        {
            return _manufacturerService.Get(id);
        }

        /// <summary>
        /// Executes a save request from a client.
        /// POST: api/Manufacturer
        /// </summary>
        /// <param name="manufacturer">The new manufacturer to be saved.</param>
        public void Post([FromBody]Manufacturer manufacturer)
        {
            _manufacturerService.Insert(manufacturer);
        }

        /// <summary>
        /// Executes an update request from a client.
        /// PUT: api/Manufacturer/5
        /// </summary>
        /// <param name="id">The id of the manufacturer to be updated.</param>
        /// <param name="manufacturer">The manufacturer with new attributes.</param>
        public void Put(int id, [FromBody]Manufacturer manufacturer)
        {
            _manufacturerService.Update(id, manufacturer);
        }

        /// <summary>
        /// Executes a delete request from a client.
        /// DELETE: api/Manufacturer/5
        /// </summary>
        /// <param name="id">The id of the manufacturer to be deleted.</param>
        public void Delete(int id)
        {
            _manufacturerService.Delete(id);
        }
    }
}
