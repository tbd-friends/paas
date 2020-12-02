using System;
using Gamer.Menu.Application.Common.Mapper;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateItem : IRequest<Guid>, IMapFrom<Item>
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}