using System;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateItem : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}