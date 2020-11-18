using System.Collections.Generic;
using MongoDB.Bson;

namespace kafka.consumers.Models
{
    public class Category
    {
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}