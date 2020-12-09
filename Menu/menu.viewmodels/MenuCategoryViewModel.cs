using System;
using System.Collections.Generic;

namespace menu.viewmodels
{
    public class MenuCategoryViewModel
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public IEnumerable<MenuItemViewModel> Items { get; set; }
    }
}