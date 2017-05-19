namespace Server.Persistence.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Server.Database;
    using Server.Models;

    /// <summary>
    /// Class that implements the <see cref="Server.Persistence.ICustomerPersistence"/> interface.
    /// The implementation uses prepared statements for the
    /// SQL commands. Before each method a connection to the database is 
    /// opened and after execution the connection is closed.
    /// </summary>
    public class CustomerPersistence : ICustomerPersistence
    {
        private const string InsertStatement = "INSERT INTO Customers VALUES (@Username, @Password, @FirstName, @LastName, 0)";
        private const string CheckUsernameStatement =
            "SELECT COUNT(c.Username) FROM Customers c WHERE c.Username = @Username";

        private const string AuthenticateStatement = "SELECT c.Id FROM Customers c WHERE c.Username = @Username AND c.Password = @Password";
        
        public int Authenticate(Customer customer)
        {
            DatabaseContext.OpenConnection();

            int id = -1;

            using (SqlCommand command = new SqlCommand(AuthenticateStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));

                command.Parameters[0].Value = customer.Username;
                command.Parameters[1].Value = customer.Password;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
            }

            DatabaseContext.CloseConnection();

            return id;
        }

        public int Insert(Customer customer)
        {
            DatabaseContext.OpenConnection();

            int id = 0;

            if (CheckUsernameAvailability(customer.Username))
            {
                

                using (SqlCommand command = new SqlCommand(InsertStatement, DatabaseContext.Connection))
                {
                    command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar));
                    command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar));

                    command.Parameters[0].Value = customer.Username;
                    command.Parameters[1].Value = customer.Password;
                    command.Parameters[2].Value = customer.FirstName;
                    command.Parameters[3].Value = customer.LastName;

                    command.ExecuteNonQuery();

                    DatabaseContext.CloseConnection();

                    id = Authenticate(customer);
                }
            }
            else
            {
                id = -1;

                DatabaseContext.CloseConnection();
            }

            return id;
        }

        public void Update(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The method checks whether a user with a name equal to the input
        /// parameter already exists in the database.
        /// </summary>
        /// <param name="username">The username to be checked.</param>
        /// <returns>True when a user with such a name exists, false otherwise.</returns>
        private bool CheckUsernameAvailability(string username)
        {
            int size = 0;

            using (SqlCommand command = new SqlCommand(CheckUsernameStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar));

                command.Parameters[0].Value = username;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        size = reader.GetInt32(0);
                    }
                }
            }

            return size == 0;
        }
    }
}