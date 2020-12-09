using System;
using System.Collections;
using System.Collections.Generic;

namespace menu.viewmodels
{
    public class MenuViewModel
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public IEnumerable<MenuCategoryViewModel> Categories { get; set; }
    }
}