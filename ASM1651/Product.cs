namespace ASM1651
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public abstract string GetAdditionalInfo();
        public abstract void UpdateAdditionalInfo(string newAdditionalInfo);

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}, Infor(Author/Size): {GetAdditionalInfo()}";
        }
    }
}
