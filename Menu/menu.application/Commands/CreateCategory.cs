using Gamer.Menu.Application.Common.Mapper;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateCategory: IRequest, IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}