using System.Collections.Generic;

namespace kafka.consumers.ConsumedModels
{
    public class Category
    {
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}