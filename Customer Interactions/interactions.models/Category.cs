using System.Collections.Generic;

namespace interactions.models
{
    public class Category
    {
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}