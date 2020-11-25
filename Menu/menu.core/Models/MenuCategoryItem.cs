using System;

namespace Gamer.Menu.Core.Models
{
    public class MenuCategoryItem
    {
        public Guid Id { get; set; }
        public Guid MenuCategoryId { get; set; }
        public Guid ItemId { get; set; }
    }
}