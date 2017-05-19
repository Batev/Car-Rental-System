namespace Server.Service.Implementation
{
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using Server.Models;
    using Server.Persistence;
    using Server.Persistence.Implementation;

    /// <summary>
    /// Class that implements the <see cref="Server.Service.ICustomerService"/> interface.
    /// The implementation checks the input parameters and makes calculations before
    /// sending the objects to the data access layer. 
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerPersistence _customerPersistance;

        public CustomerService()
        {
            this._customerPersistance = new CustomerPersistence();
        }

        public int Insert(Customer customer)
        {
            int id = -1;

            if (customer != null)
            {
                byte[] usernameToBytes = Encoding.ASCII.GetBytes(customer.Username);
                byte[] passwordToBytes = Encoding.ASCII.GetBytes(customer.Password);

                customer.Password = ComputePasswordSaltedHash(passwordToBytes, usernameToBytes);
                
                if (string.IsNullOrEmpty(customer.FirstName) &&
                    string.IsNullOrEmpty(customer.LastName) &&
                    (customer.Id == -1))
                {
                    id = _customerPersistance.Authenticate(customer);
                }
                else
                {
                    id = _customerPersistance.Insert(customer);
                }
            }

            return id;
        }

        public void Update(int id, Customer customer)
        {
            _customerPersistance.Update(id, customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerPersistance.GetAll();
        }

        public Customer Get(int id)
        {
            return _customerPersistance.Get(id);
        }

        public void Delete(int id)
        {
            _customerPersistance.Delete(id);
        }

        /// <summary>
        /// Computes the SHA256 hash for a given password and a salt.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <param name="salt">The salt to be used.</param>
        /// <returns>The salt-hashed as a string.</returns>
        private string ComputePasswordSaltedHash(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }

            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            return Encoding.ASCII.GetString(algorithm.ComputeHash(plainTextWithSaltBytes));
        }
    }
}