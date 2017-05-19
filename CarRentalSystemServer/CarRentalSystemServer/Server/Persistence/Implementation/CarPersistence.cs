namespace Server.Persistence.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Server.Database;
    using Server.Models;

    /// <summary>
    /// Class that implements the <see cref="Server.Persistence.ICarPersistence"/> interface.
    /// The implementation uses prepared statements for the
    /// SQL commands. Before each method a connection to the database is 
    /// opened and after execution the connection is closed.
    /// </summary>
    public class CarPersistance : ICarPersistence
    {
        private const string SearchByModelStatement = "SELECT c.Id,m.Name as ManufacturerId,c.Model,c.Price,c.IsAvailable,c.IsDeleted FROM Cars c JOIN Manufacturers m ON c.ManufacturerId = m.Id WHERE m.Id = @Id AND c.IsDeleted = 0 AND c.IsAvailable = 1";
        private const string GetAllStatement = "SELECT c.Id,m.Name as ManufacturerId,c.Model,c.Price,c.IsAvailable,c.IsDeleted FROM Cars c JOIN Manufacturers m ON c.ManufacturerId = m.Id WHERE c.IsDeleted = 0 AND c.IsAvailable = 1";
        private const string UpdateAvailabilityStatement = "UPDATE Cars SET IsAvailable = @IsAvailable WHERE Id = @Id";
        private const string DeleteStatement = "UPDATE Cars SET IsDeleted = @IsDeleted WHERE Id = @Id";
        
        public void Insert(Car car)
        {
            throw new NotImplementedException();
        }

        public ICollection<Car> Search(int manufacturerId)
        {
            DatabaseContext.OpenConnection();
            ICollection<Car> collection = new List<Car>();

            using (SqlCommand command = new SqlCommand(SearchByModelStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters[0].Value = manufacturerId;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collection.Add(new Car
                        {
                            Id = reader.GetInt32(0),
                            ManufacturerId = reader.GetString(1),
                            Model = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            IsAvailable = reader.GetBoolean(4),
                            IsDeleted = reader.GetBoolean(5)
                        });
                    }
                }
            }

            DatabaseContext.CloseConnection();

            return collection;
        }

        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Car> GetAll()
        {
            DatabaseContext.OpenConnection();
            ICollection<Car> collection = new List<Car>();
            using (SqlCommand command = new SqlCommand(GetAllStatement, DatabaseContext.Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collection.Add(new Car
                        {
                            Id = reader.GetInt32(0),
                            ManufacturerId = reader.GetString(1),
                            Model = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            IsAvailable = reader.GetBoolean(4),
                            IsDeleted = reader.GetBoolean(5)
                        });
                    }
                }
            }

            DatabaseContext.CloseConnection();

            return collection;
        }

        public void Update(int id, Car car)
        {
            DatabaseContext.OpenConnection();

            using (SqlCommand command = new SqlCommand(UpdateAvailabilityStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@IsAvailable", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters[0].Value = car.IsAvailable;
                command.Parameters[1].Value = id;

                command.ExecuteNonQuery();
            }

            DatabaseContext.CloseConnection();
        }

        public void Delete(int id)
        {
            DatabaseContext.OpenConnection();
            using (SqlCommand command = new SqlCommand(DeleteStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters[0].Value = true;
                command.Parameters[1].Value = id;

                command.ExecuteNonQuery();
            }

            DatabaseContext.CloseConnection();
        }
    }
}