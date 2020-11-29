using Gamer.Menu.Application.Common.Mapper;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateItem : IRequest, IMapFrom<Item>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}