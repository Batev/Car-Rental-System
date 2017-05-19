namespace Client.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Context;
    using Model;

    /// <summary>
    /// Class that implements the <see cref="ICarClient"/> interface 
    /// and the <see cref="ObjectClient"/> abstract class.
    /// </summary>
    public class CarClient : ObjectClient, ICarClient
    {
        private const string CarUrl = "api/Car";

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await GetAllObjectsAsync<Car>(CarUrl);
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await GetObjectByIdAsync<Car>(CarUrl, id);
        }

        public async Task AddCarAsync(Car car)
        {
            await AddObject<Car>(CarUrl, car);
        }

        public async Task UpdateCarAsync(int id, Car car)
        {
            await UpdateObject<Car>(CarUrl, id, car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await DeleteObject(CarUrl, id);
        }

        public async Task<IEnumerable<Car>> GetCarsByManufacturerAsync(int manufacturerId)
        {
            IEnumerable<Car> cars = null;

            HttpResponseMessage response = await HttpClientContext.GetHttpClient().GetAsync(String.Concat(CarUrl, "/", manufacturerId.ToString()));

            if (response.IsSuccessStatusCode)
            {
                cars = await response.Content.ReadAsAsync<IEnumerable<Car>>();
            }

            return cars;
        }
    }
}
