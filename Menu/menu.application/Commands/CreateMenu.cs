using System;
using MediatR;
using ModelMenu = Gamer.Menu.Core.Models.Menu;


namespace Gamer.Menu.Application.Commands
{
    public class CreateMenu : IRequest
    {
        public string Name { get; set; }
    }
}