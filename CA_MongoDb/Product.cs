using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_MongoDb
{
    public class Product
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("price")]
        public double price { get; set; }

        [BsonElement("quantity")]
        public int quantity { get; set; }

        [BsonElement("status")]
        public bool status { get; set; }

        [BsonElement("date")]
        public DateTime date { get; set; }

        [BsonElement("categoryId")]
        public int categoryId { get; set; }

        [BsonElement("isActive")]
        public bool isActive { get; set; }
    }
}
