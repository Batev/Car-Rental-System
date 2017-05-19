namespace Server.Models
{
    /// <summary>
    /// An entity class for a transfer object (DTO).
    /// </summary>
    public class Car
    {
        public Car()
        {
            
        }

        public Car(int id, string model, decimal price, string manufacturerId, bool isAvailable, bool isDeleted)
        {
            Id = id;
            Price = price;
            Model = model;
            ManufacturerId = manufacturerId;
            IsAvailable = isAvailable;
            IsDeleted = isDeleted;
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string ManufacturerId { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsDeleted { get; set; }
    }
}