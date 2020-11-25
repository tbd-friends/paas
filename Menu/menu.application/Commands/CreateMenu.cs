using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateMenu : IRequest
    {
        public string Name { get; set; }
    }
}