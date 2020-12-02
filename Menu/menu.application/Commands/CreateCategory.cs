using System;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateCategory: IRequest<Guid>
    {
        public string Name { get; set; }
    }
}