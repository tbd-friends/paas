using System;
using System.Collections.Generic;

namespace Gamer.Menu.Website.Models
{
    public class Menu
    {
        public Guid UID { get; set; }
        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}