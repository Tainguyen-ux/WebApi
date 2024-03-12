namespace _01_GettingStarted.Models
{
    public class ProductVM
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }
    public class Product:ProductVM
    {
        public Guid ID { get; set; }

    }
}
