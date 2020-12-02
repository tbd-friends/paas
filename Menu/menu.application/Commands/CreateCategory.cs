using System;
using Gamer.Menu.Application.Common.Mapper;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateCategory: IRequest<Guid>, IMapFrom<Category>
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
    }
}