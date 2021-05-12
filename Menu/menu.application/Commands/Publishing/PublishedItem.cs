using System;

namespace Gamer.Menu.Application.Commands.Publishing
{
    public class PublishedItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}