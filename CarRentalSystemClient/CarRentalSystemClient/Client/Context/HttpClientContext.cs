namespace Client.Context
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    /// <summary>
    /// A singleton class that gives the user a static
    /// HTTP client object. There is a base initialization
    /// of the client.
    /// </summary>
    public class HttpClientContext
    {
        /// <summary>
        /// The HTTP client object.
        /// </summary>
        private static HttpClient _client;

        /// <summary>
        /// Initializes a HTTP set to a local host.
        /// Due to the singleton pattern, the client
        /// could be initialized only once.
        /// </summary>
        public static void InitializeHttpClient()
        {
            if (_client == null)
            {
                _client = new HttpClient() { };
                _client.BaseAddress = new Uri("http://localhost:22200/");
                //_client.BaseAddress = new Uri("http://carrentalsystem.azurewebsites.net/");
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        /// <summary>
        /// Disposes the HTTP client.
        /// Mainly used at the end of the program execution. 
        /// </summary>
        public static void DisposeHttpClient()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }

        /// <summary>
        /// Gets the HTTP client object.
        /// </summary>
        /// <returns>The HTTP client object.</returns>
        public static HttpClient GetHttpClient()
        {
            return _client;
        }
    }
}