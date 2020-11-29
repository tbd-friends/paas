using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gamer.Menu.Core;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateCategoryHandler : AsyncRequestHandler<CreateCategory>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override Task Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            _context.Insert(_mapper.Map<Core.Models.Category>(request));
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}