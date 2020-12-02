using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gamer.Menu.Core;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, Guid>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var newEntity = _mapper.Map<Core.Models.Category>(request);
            newEntity.UID = Guid.NewGuid();
            _context.Insert(newEntity);
            _context.SaveChanges();
            return newEntity.UID;
        }
    }
}