namespace Model
{
    using System;

    /// <summary>
    /// An entity class for a transfer object (DTO).
    /// </summary>
    public class RentedCar
    {
        public RentedCar()
        {
            
        }

        public RentedCar(int id, string manufacturer, string model, decimal price, DateTime rentedOn, DateTime returnedOn)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            RentedOn = rentedOn;
            ReturnedOn = returnedOn;
        }

        public int Id { get; set; }

        public int CarId { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DateTime RentedOn { get; set; }

        public DateTime? ReturnedOn { get; set; }
    }
}