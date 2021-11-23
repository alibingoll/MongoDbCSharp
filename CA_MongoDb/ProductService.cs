using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
namespace CA_MongoDb
{
    public class ProductService
    {
        private static ProductService _client;
        private static object lockObject = new object();

        private MongoClient mongoClient;
        private IMongoCollection<Product> productCollection;

        public ProductService()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            var dataBase = mongoClient.GetDatabase("myDemo");
            productCollection = dataBase.GetCollection<Product>("mydemo");
        }

        public void ProductInsert()
        {
            Product product = new Product
            {
                name = "Ali",
                price = 11,
                quantity = 11,
                status = true,
                categoryId = 11,
                date = DateTime.Now,
                isActive = true
            };
            productCollection.InsertOne(product);
        }
        public void ProductUpdate(string id)
        {
            var result = productCollection.UpdateOne(
                Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<Product>.Update
                .Set("price", 525)
                .Set("quantity", 888)
                );
        }
        public bool ProductDelete(string id)
        {
            var result = productCollection.DeleteOne(
                Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id)));
            return Convert.ToBoolean(result.DeletedCount);
        }

        public void ProductListWhere(bool status)
        {
            var products = productCollection.AsQueryable<Product>().Where(p => p.status == status);
            foreach (var product in products)
            {
                Console.WriteLine("İd : " + product.id);
                Console.WriteLine("Name : " + product.name);
                Console.WriteLine("Price : " + product.price);
                Console.WriteLine("Quantity : " + product.quantity);
                Console.WriteLine("Status : " + product.status);
                Console.WriteLine("Date : " + product.date);
                Console.WriteLine("CategoryId : " + product.categoryId);
                Console.WriteLine("Aktif mi : " + product.isActive);
                Console.WriteLine("_______________________");
            }
        }

        public void ProductList()
        {
            var products = productCollection.AsQueryable<Product>().ToList();
            foreach (var product in products)
            {
                Console.WriteLine("İd : " + product.id);
                Console.WriteLine("Name : " + product.name);
                Console.WriteLine("Price : " + product.price);
                Console.WriteLine("Quantity : " + product.quantity);
                Console.WriteLine("Status : " + product.status);
                Console.WriteLine("Date : " + product.date);
                Console.WriteLine("CategoryId : " + product.categoryId);
                Console.WriteLine("Aktif mi : " + product.isActive);
                Console.WriteLine("_______________________");
            }
        }
    }
}
