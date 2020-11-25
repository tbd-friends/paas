using Gamer.Menu.Application.Common.Mapper;
using MediatR;
using ModelMenu = Gamer.Menu.Core.Models.Menu;


namespace Gamer.Menu.Application.Commands
{
    public class CreateMenu : IRequest, IMapFrom<ModelMenu>
    {
        public string Name { get; set; }
    }
}