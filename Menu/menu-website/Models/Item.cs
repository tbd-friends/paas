using System.Collections.Generic;
using MongoDB.Bson;

namespace kafka.consumers.Models
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}