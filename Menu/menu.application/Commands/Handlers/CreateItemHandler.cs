using System;
using System.Threading;
using System.Threading.Tasks;
using Gamer.Menu.Core;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateItemHandler : IRequestHandler<CreateItem, Guid>
    {
        private readonly IApplicationContext _context;

        public CreateItemHandler(IApplicationContext context)
        {
            _context = context;
        }

        public Task<Guid> Handle(CreateItem request, CancellationToken cancellationToken)
        {
            var newEntity = new Item
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };
            _context.Insert(newEntity);
            _context.SaveChanges();
            return Task.FromResult(newEntity.UID);
        }
    }
}