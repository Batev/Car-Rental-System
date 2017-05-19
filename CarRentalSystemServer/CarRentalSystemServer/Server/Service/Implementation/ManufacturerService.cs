namespace Server.Service.Implementation
{
    using System.Collections.Generic;
    using Server.Models;
    using Server.Persistence;
    using Server.Persistence.Implementation;

    /// <summary>
    /// Class that implements the <see cref="Server.Service.IManufacturerService"/> interface.
    /// The implementation checks the input parameters and makes calculations before
    /// sending the objects to the data access layer. 
    /// </summary>
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerPersistence _manufacturerPersistance;

        public ManufacturerService()
        {
            this._manufacturerPersistance = new ManufacturerPersistence();
        }

        public void Insert(Manufacturer manufacturer)
        {
            _manufacturerPersistance.Insert(manufacturer);
        }

        public void Update(int id, Manufacturer manufacturer)
        {
            _manufacturerPersistance.Update(id, manufacturer);
        }

        public ICollection<Manufacturer> GetAll()
        {
            return _manufacturerPersistance.GetAll();
        }

        public Manufacturer Get(int id)
        {
            return _manufacturerPersistance.Get(id);
        }

        public void Delete(int id)
        {
            _manufacturerPersistance.Delete(id);
        }
    }
}