using System;

namespace Gamer.Menu.Website.Models
{
    public class Item
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}