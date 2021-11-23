using System;

namespace CA_MongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            //productService.ProductInsert();
            //productService.ProductList();
            //productService.ProductUpdate("619ca8f2474f66d3d7add395");
            //var isDeleted = productService.ProductDelete("619ca8f2474f66d3d7add395");
            productService.ProductListWhere(false);
            Console.WriteLine("Listelendi");
            Console.ReadKey();
        }
    }
}
