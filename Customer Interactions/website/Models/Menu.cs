using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamer.Customer.Website.Models
{
    public class Menu
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}