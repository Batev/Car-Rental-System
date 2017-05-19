namespace Client.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Context;

    /// <summary>
    /// An abstract class that gives base implementations
    /// for the essential CRUD(create,read,update and delete)
    /// operations. The methods work asynchronously, because
    /// they use a HTTP client to communicate with the server.
    /// </summary>
    public abstract class ObjectClient
    {
        protected async Task<IEnumerable<T>> GetAllObjectsAsync<T>(string url)
        {
            IEnumerable<T> objects = null;

            HttpResponseMessage response = await HttpClientContext.GetHttpClient().GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                objects = await response.Content.ReadAsAsync<IEnumerable<T>>();
            }

            return objects;
        }
        
        protected async Task<T> GetObjectByIdAsync<T>(string url, int id)
        {
            T entity = default(T);

            HttpResponseMessage response = await HttpClientContext.GetHttpClient().GetAsync(String.Concat(url, "/", id.ToString()));

            if (response.IsSuccessStatusCode)
            {
                entity = await response.Content.ReadAsAsync<T>();
            }

            return entity;
        }

        protected async Task DeleteObject(string url, int id)
        {
            HttpResponseMessage response = await HttpClientContext.GetHttpClient().DeleteAsync(String.Concat(url, "/", id.ToString()));
        }

        protected async Task UpdateObject<T>(string url, int id, T model)
        {
            HttpResponseMessage response = await HttpClientContext.GetHttpClient().PutAsJsonAsync(String.Concat(url, "/", id), model);
        }

        protected async Task AddObject<T>(string url, T model)
        {
            HttpResponseMessage response = await HttpClientContext.GetHttpClient().PostAsJsonAsync(url, model);
        }
    }
}