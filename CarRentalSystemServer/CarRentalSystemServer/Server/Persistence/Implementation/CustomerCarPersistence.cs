namespace Server.Persistence.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Server.Database;
    using Server.Models;

    /// <summary>
    /// Class that implements the <see cref="Server.Persistence.ICustomerCarPersistence"/> interface.
    /// The implementation uses prepared statements for the
    /// SQL commands. Before each method a connection to the database is 
    /// opened and after execution the connection is closed.
    /// </summary>
    public class CustomerCarPersistence : ICustomerCarPersistence
    {
        private const string InsertStatement = "INSERT INTO CustomersCars VALUES (@CarId, @CustomerId, @RentedOn, NULL)";
        private const string UpdateDateStatement = "UPDATE CustomersCars SET ReturnedOn = @ReturnedOn WHERE Id = @Id";
        private const string GetByCustomerIdStatement =
            "SELECT cc.Id, m.Name,c.Model,c.Price,cc.RentedOn,cc.ReturnedOn, cc.CarId FROM CustomersCars cc JOIN Cars c ON cc.CarId = c.Id JOIN Manufacturers m ON m.Id = c.ManufacturerId WHERE cc.CustomerId = @Id";

        public void Insert(CustomerCar customerCar)
        {
            DatabaseContext.OpenConnection();

            using (SqlCommand sqlCommand = new SqlCommand(InsertStatement, DatabaseContext.Connection))
            {
                sqlCommand.Parameters.Add("@CarId", SqlDbType.Int);
                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.Int);
                sqlCommand.Parameters.Add("@RentedOn", SqlDbType.Date);

                sqlCommand.Parameters[0].Value = customerCar.CarId;
                sqlCommand.Parameters[1].Value = customerCar.CustomerId;
                sqlCommand.Parameters[2].Value = DateTime.Now;

                sqlCommand.ExecuteNonQuery();
            }

            DatabaseContext.CloseConnection();
        }

        public void Update(int id, CustomerCar customerCar)
        {
            DatabaseContext.OpenConnection();

            using (SqlCommand sqlCommand = new SqlCommand(UpdateDateStatement, DatabaseContext.Connection))
            {
                sqlCommand.Parameters.Add("@ReturnedOn", SqlDbType.Date);
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int);

                sqlCommand.Parameters[0].Value = DateTime.Now;
                sqlCommand.Parameters[1].Value = id;

                sqlCommand.ExecuteNonQuery();
            }

            DatabaseContext.CloseConnection();
         }

        public IEnumerable<CustomerCar> GetAll()
        {
            throw new NotImplementedException();
        } 

        public CustomerCar Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentedCar> GetByCustomerId(int id)
        {
            DatabaseContext.OpenConnection();

            ICollection<RentedCar> collection = new List<RentedCar>();

            using (SqlCommand command = new SqlCommand(GetByCustomerIdStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters[0].Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime? returnedOn = null;
                        
                        if (!reader.IsDBNull(5))
                        {
                            returnedOn = reader.GetDateTime(5);
                        }
                        RentedCar rentedCar = new RentedCar(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetDateTime(4), returnedOn);
                        rentedCar.CarId = reader.GetInt32(6);
                        collection.Add(rentedCar);
                    }
                }
            }

            DatabaseContext.CloseConnection();

            return collection;
        }
    }
}