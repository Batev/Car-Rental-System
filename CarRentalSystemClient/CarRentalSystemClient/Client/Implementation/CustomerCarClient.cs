namespace Client.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Context;
    using Model;

    /// <summary>
    /// Class that implements the <see cref="ICustomerCarClient"/> interface 
    /// and the <see cref="ObjectClient"/> abstract class.
    /// </summary>
    public class CustomerCarClient : ObjectClient, ICustomerCarClient
    {
        private const string CustomerCarUrl = "api/CustomerCar";

        public async Task<IEnumerable<CustomerCar>> GetAllCustomerCarsAsync()
        {
            return await GetAllObjectsAsync<CustomerCar>(CustomerCarUrl);
        }

        public async Task<CustomerCar> GetCustomerCarByIdAsync(int id)
        {
            return await GetObjectByIdAsync<CustomerCar>(CustomerCarUrl, id);
        }

        public async Task AddCustomerCarAsync(CustomerCar customerCar)
        {
            await AddObject<CustomerCar>(CustomerCarUrl, customerCar);
        }

        public async Task UpdateCustomerCarAsync(int id, CustomerCar customerCar)
        {
            await UpdateObject<CustomerCar>(CustomerCarUrl, id, customerCar);
        }
        
        public async Task DeleteCarAsync(int id)
        {
            await DeleteObject(CustomerCarUrl, id);
        }

        public async Task<IEnumerable<RentedCar>> GetByCostumerIdAsync(int id)
        {
            IEnumerable<RentedCar> cars = null;

            HttpResponseMessage response = await HttpClientContext.GetHttpClient().GetAsync(String.Concat(CustomerCarUrl, "/", id.ToString()));

            if (response.IsSuccessStatusCode)
            {
                cars = await response.Content.ReadAsAsync<IEnumerable<RentedCar>>();
            }

            return cars;
        }
    }
}