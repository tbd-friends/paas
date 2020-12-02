using System;
using Gamer.Menu.Application.Common.Mapper;
using MediatR;
using ModelMenu = Gamer.Menu.Core.Models.Menu;


namespace Gamer.Menu.Application.Commands
{
    public class CreateMenu : IRequest, IMapFrom<ModelMenu>
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
    }
}