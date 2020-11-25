using System.Collections.Generic;

namespace Gamer.Menu.Website.Models
{
    public class Category
    {
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}