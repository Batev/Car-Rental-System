namespace Server.Models
{
    /// <summary>
    /// An entity class for a transfer object (DTO).
    /// </summary>
    public class Customer
    {
        public Customer()
        {
            
        }

        public Customer(int id, string username, string password, string firstName, string lastName, bool isDeleted)
        {
            IsDeleted = isDeleted;
            LastName = lastName;
            FirstName = firstName;
            Password = password;
            Id = id;
            Username = username;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
    }
}