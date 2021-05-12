using System;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class PublishMenu : IRequest
    {
        public Guid Id { get; set; }
    }
}