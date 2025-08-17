namespace BO
{
    public class Customer
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string? Address { get; set; }

        public Customer(int id, string name, int phone, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
        }

        public Customer() { }
    }
}
