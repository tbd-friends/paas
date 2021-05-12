using System;
using System.Collections.Generic;

namespace kafka.consumers.ConsumedModels
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}