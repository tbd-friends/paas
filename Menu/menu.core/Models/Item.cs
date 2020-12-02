using System;

namespace Gamer.Menu.Core.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}