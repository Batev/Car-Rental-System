namespace Server.Service.Implementation
{
    using System.Collections.Generic;
    using Server.Models;
    using Server.Persistence;
    using Server.Persistence.Implementation;

    /// <summary>
    /// Class that implements the <see cref="Server.Service.ICustomerCarService"/> interface.
    /// The implementation checks the input parameters and makes calculations before
    /// sending the objects to the data access layer. 
    /// </summary>
    public class CustomerCarService : ICustomerCarService
    {
        private readonly ICustomerCarPersistence _customerCarPersistence;
        private readonly ICarPersistence _carPersistence;

        public CustomerCarService()
        {
            _customerCarPersistence = new CustomerCarPersistence();
            _carPersistence = new CarPersistance();
        }

        public void Insert(CustomerCar customerCar)
        {
            _customerCarPersistence.Insert(customerCar);
            _carPersistence.Update(customerCar.CarId, new Car() { IsAvailable = false });
        }

        public void Update(int id, CustomerCar customerCar)
        {
            _customerCarPersistence.Update(id, customerCar);
            _carPersistence.Update(customerCar.CarId, new Car() { IsAvailable = true });
        }

        public IEnumerable<CustomerCar> GetAll()
        {
            return _customerCarPersistence.GetAll();
        }

        public CustomerCar Get(int id)
        {
            return _customerCarPersistence.Get(id);
        }

        public void Delete(int id)
        {
            _customerCarPersistence.Delete(id);
        }

        public IEnumerable<RentedCar> GetByCustomerId(int id)
        {
            return _customerCarPersistence.GetByCustomerId(id);
        }
    }
}