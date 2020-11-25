using System;

namespace Gamer.Menu.Core.Models
{
    public class MenuCategory
    {
        public Guid Id { get; set; }
        public Guid MenuId { get; set; }
        public Guid CategoryId { get; set; }
    }
}