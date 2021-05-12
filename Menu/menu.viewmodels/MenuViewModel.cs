using System;
using System.Collections.Generic;
using System.Linq;

namespace menu.viewmodels
{
    public class MenuViewModel
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public IEnumerable<MenuCategoryViewModel> Categories { get; set; }

        public bool CanBePublished => 
            Categories.Any() && Categories.All(c => c.Items.Any());
    }
}