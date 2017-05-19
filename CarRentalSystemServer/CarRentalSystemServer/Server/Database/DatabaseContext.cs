namespace Server.Database
{
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// A singleton class for establishing connection to the database
    /// using a connection string.
    /// </summary>
    public class DatabaseContext
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;

        /// <summary>
        /// The connection object.
        /// </summary>
        private static SqlConnection _connection;
        
        /// <summary>
        /// Gets the connection object.
        /// </summary>
        public static SqlConnection Connection
        {
            get { return _connection; }
        }

        /// <summary>
        /// Opens the connection to the database.
        /// Due to the singleton pattern the connection
        /// could be opened only once.
        /// </summary>
        public static void OpenConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
            }
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public static void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}