using System;
using System.Collections.Generic;
using Gamer.Menu.Application.Common.Mapper;

namespace Gamer.Menu.Website.Models
{
    public class Menu : IMapFrom<Core.Models.Menu>
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}