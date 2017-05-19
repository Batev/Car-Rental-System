namespace Server.Service.Implementation
{
    using System.Collections.Generic;
    using Server.Models;
    using Server.Persistence;
    using Server.Persistence.Implementation;

    /// <summary>
    /// Class that implements the <see cref="Server.Service.ICarService"/> interface.
    /// The implementation checks the input parameters and makes calculations before
    /// sending the objects to the data access layer. 
    /// </summary>
    public class CarService : ICarService
    {
        private readonly ICarPersistence _carPersistence;

        public CarService()
        {
            _carPersistence = new CarPersistance();
        }

        public void Insert(Car car)
        {
            _carPersistence.Insert(car);
        }

        public void Update(int id, Car car)
        {
            _carPersistence.Update(id, car);
        }

        public Car Get(int id)
        {
            return _carPersistence.Get(id);
        }

        public ICollection<Car> GetAll()
        {
            return _carPersistence.GetAll();
        }

        public void Delete(int id)
        {
            _carPersistence.Delete(id);
        }

        public ICollection<Car> GetCarsByManufacturerId(int id)
        {
            return _carPersistence.Search(id);
        }
    }
}
