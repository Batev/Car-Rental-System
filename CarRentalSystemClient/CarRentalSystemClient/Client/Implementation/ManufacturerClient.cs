namespace Client.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    /// <summary>
    /// Class that implements the <see cref="IManufacturerClient"/> interface 
    /// and the <see cref="ObjectClient"/> abstract class.
    /// </summary>
    public class ManufacturerClient : ObjectClient, IManufacturerClient
    {
        private const string ManufacturerUrl = "api/Manufacturer";

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync()
        {

            return await GetAllObjectsAsync<Manufacturer>(ManufacturerUrl);
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int id)
        {
            return await GetObjectByIdAsync<Manufacturer>(ManufacturerUrl, id);
        }
        
        public async Task AddManufacturerAsync(Manufacturer manufacturer)
        {
            await AddObject<Manufacturer>(ManufacturerUrl, manufacturer);
        }

        public async Task UpdateManufacturerAsync(int id, Manufacturer manufacturer)
        {
            await UpdateObject<Manufacturer>(ManufacturerUrl, id, manufacturer);
        }

        public async Task DeleteManufacturerAsync(int id)
        {
            await DeleteObject(ManufacturerUrl, id);
        }
    }
}