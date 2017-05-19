namespace Model
{
    using System;

    /// <summary>
    /// An entity class for a transfer object (DTO).
    /// </summary>
    public class CustomerCar
    {
        public CustomerCar()
        {
            
        }

        public CustomerCar(int id, int carId, int customerId, DateTime rentedOn, DateTime? returnedOn)
        {
            Id = id;
            CarId = carId;
            CustomerId = customerId;
            RentedOn = rentedOn;
            ReturnedOn = returnedOn;
        }

        public int Id { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public DateTime RentedOn { get; set; }

        public DateTime? ReturnedOn { get; set; }
    }
}