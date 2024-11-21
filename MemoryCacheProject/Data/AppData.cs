using MemoryCache.Models;

namespace MemoryCache.Data;

public static class AppData
{
    public static List<Product>? Estoque()
    {
        return
        [
            new Product(1, "Product 1", 10.0m),
            new Product(2, "Product 2", 20.0m),
            new Product(3, "Product 3", 30.0m),
            new Product(4, "Product 4", 40.0m),
            new Product(5, "Product 5", 50.0m),
            new Product(6, "Product 6", 60.0m),
            new Product(7, "Product 7", 70.0m),
            new Product(8, "Product 8", 80.0m),
            new Product(9, "Product 9", 90.0m),
            new Product(10, "Product 10", 100.0m)
        ];
        
    }
}