using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gamer.Menu.Core;
using MediatR;
using ModelMenu = Gamer.Menu.Core.Models.Menu;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateMenuHandler : AsyncRequestHandler<CreateMenu>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateMenuHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override Task Handle(CreateMenu request, CancellationToken cancellationToken)
        {
            _context.Insert(_mapper.Map<ModelMenu>(request));

            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}