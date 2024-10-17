namespace Products.Models
{
    public class Context
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product {Id=1,Name="Laptop",Price=2000,Description="New Laptop"},
            new Product {Id=2,Name="SmartPhone",Price=1000,Description="Used"},
            new Product {Id=3,Name="Tablet",Price=2500,Description="New Tablet"},
        };
    }
}
