using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gamer.Menu.Core;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateItemHandler : AsyncRequestHandler<CreateItem>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateItemHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override Task Handle(CreateItem request, CancellationToken cancellationToken)
        {
            _context.Insert(_mapper.Map<Item>(request));
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}