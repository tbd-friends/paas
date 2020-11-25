using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace interactions.models
{
    public class Menu
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid SourceMenuId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}