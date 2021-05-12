using System;
using System.Collections.Generic;

namespace kafka.consumers.ConsumedModels
{
    public class Menu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}