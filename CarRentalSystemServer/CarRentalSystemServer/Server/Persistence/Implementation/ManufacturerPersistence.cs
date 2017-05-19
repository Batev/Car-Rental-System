namespace Server.Persistence.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Server.Database;
    using Server.Models;

    /// <summary>
    /// Class that implements the <see cref="Server.Persistence.IManufacturerPersistence"/> interface.
    /// The implementation uses prepared statements for the
    /// SQL commands. Before each method a connection to the database is 
    /// opened and after execution the connection is closed.
    /// </summary>
    public class ManufacturerPersistence : IManufacturerPersistence
    {
        private const string InsertStatement = "INSERT INTO Manufacturers VALUES (@name, 0)";
        private const string DeleteStatement = "UPDATE Manufacturers SET IsDeleted = 1 WHERE Id = @id";
        private const string GetAllStatement = "SELECT * FROM Manufacturers m WHERE m.IsDeleted = 0";

        public void Insert(Manufacturer manufacturer)
        {
            Database.DatabaseContext.OpenConnection();

            using (SqlCommand command = new SqlCommand(InsertStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));

                command.Parameters[0].Value = manufacturer.Name;

                command.ExecuteNonQuery();
            }

            DatabaseContext.CloseConnection();
        }

        public void Update(int id, Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            DatabaseContext.OpenConnection();

            using (SqlCommand command = new SqlCommand(DeleteStatement, DatabaseContext.Connection))
            {
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));

                command.Parameters[0].Value = id;

                command.ExecuteNonQuery();
            }

            DatabaseContext.CloseConnection();
        }
        
        public Manufacturer Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Manufacturer> GetAll()
        {
            DatabaseContext.OpenConnection();

            ICollection<Manufacturer> collection = new List<Manufacturer>();

            using (SqlCommand command = new SqlCommand(GetAllStatement, DatabaseContext.Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collection.Add(new Manufacturer(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2)));
                    }
                }
            }

            DatabaseContext.CloseConnection();

            return collection;
        }
    }
}