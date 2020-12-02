using System;
using System.Threading;
using System.Threading.Tasks;
using Gamer.Menu.Core;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, Guid>
    {
        private readonly IApplicationContext _context;

        public CreateCategoryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public Task<Guid> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var newEntity = new Category
            {
                Name = request.Name
            };
            _context.Insert(newEntity);
            _context.SaveChanges();
            return Task.FromResult(newEntity.UID);
        }
    }
}