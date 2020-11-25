using System.Collections.Generic;

namespace Gamer.Menu.Website.Models
{
    public class Menu
    {
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}