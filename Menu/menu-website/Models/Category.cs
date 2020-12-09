using System;
using System.Collections.Generic;

namespace Gamer.Menu.Website.Models
{
    public class Category
    {
        public Guid UID { get; set; }
        public string Name { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}