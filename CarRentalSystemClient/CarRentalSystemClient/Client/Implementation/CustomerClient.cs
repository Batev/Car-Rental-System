namespace Client.Implementation
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Context;
    using Model;

    /// <summary>
    /// Class that implements the <see cref="ICustomerClient"/> interface 
    /// and the <see cref="ObjectClient"/> abstract class.
    /// </summary>
    public class CustomerClient : ObjectClient, ICustomerClient
    {
        private const string CustomerUrl = "api/Customer";

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await GetAllObjectsAsync<Customer>(CustomerUrl);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await GetObjectByIdAsync<Customer>(CustomerUrl, id);
        }
        
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await HttpClientContext.GetHttpClient().PostAsJsonAsync(CustomerUrl, customer);

            return await response.Content.ReadAsAsync<int>();
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            await UpdateObject<Customer>(CustomerUrl, id, customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await DeleteObject(CustomerUrl, id);
        }
    }
}