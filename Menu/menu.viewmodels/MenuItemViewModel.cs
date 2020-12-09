using System;

namespace menu.viewmodels
{
    public class MenuItemViewModel
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}