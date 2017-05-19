namespace Model
{
    /// <summary>
    /// An entity class for a transfer object (DTO).
    /// </summary>
    public class Manufacturer
    {
        public Manufacturer()
        {
            
        }

        public Manufacturer(int id, string name, bool isDeleted)
        {
            this.Id = id;
            this.Name = name;
            this.IsDeleted = isDeleted;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}