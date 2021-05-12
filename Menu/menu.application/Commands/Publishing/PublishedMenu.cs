using System;
using System.Collections.Generic;

namespace Gamer.Menu.Application.Commands.Publishing
{
    public class PublishedMenu
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PublishedCategory> Categories { get; set; }
    }
}