using System.Threading;
using System.Threading.Tasks;
using Gamer.Menu.Core;
using MediatR;
using ModelMenu = Gamer.Menu.Core.Models.Menu;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateMenuHandler : AsyncRequestHandler<CreateMenu>
    {
        private readonly IApplicationContext _context;

        public CreateMenuHandler(IApplicationContext context)
        {
            _context = context;
        }

        protected override Task Handle(CreateMenu request, CancellationToken cancellationToken)
        {
            _context.Insert(new ModelMenu
            {
                Name = request.Name
            });
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}