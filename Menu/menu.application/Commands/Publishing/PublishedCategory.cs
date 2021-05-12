using System;
using System.Collections.Generic;

namespace Gamer.Menu.Application.Commands.Publishing
{
    public class PublishedCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PublishedItem> Items { get; set; }
    }
}