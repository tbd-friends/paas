using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gamer.Menu.Core;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateItemHandler : IRequestHandler<CreateItem, Guid>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateItemHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateItem request, CancellationToken cancellationToken)
        {
            var newEntity = _mapper.Map<Core.Models.Item>(request);
            newEntity.UID = Guid.NewGuid();
            _context.Insert(newEntity);
            _context.SaveChanges();
            return newEntity.UID;
        }
    }
}