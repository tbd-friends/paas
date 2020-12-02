using System;
using System.Collections.Generic;
using Gamer.Menu.Application.Common.Mapper;

namespace Gamer.Menu.Website.Models
{
    public class Category : IMapFrom<Core.Models.Category>
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}