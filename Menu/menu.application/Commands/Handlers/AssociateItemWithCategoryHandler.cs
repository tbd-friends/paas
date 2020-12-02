using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gamer.Menu.Core;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class AssociateItemWithCategoryHandler : AsyncRequestHandler<AssociateItemWithCategory>
    {
        private readonly IApplicationContext _context;

        public AssociateItemWithCategoryHandler(IApplicationContext context)
        {
            _context = context;
        }

        protected override Task Handle(AssociateItemWithCategory request, CancellationToken cancellationToken)
        {
            var item = _context.Items.FirstOrDefault(c => c.UID == request.ItemUID);
            foreach (var categoryUID in request.CategoryUIDS)
            {
                var category = _context.Categories.FirstOrDefault(c => c.UID == categoryUID);
                if (!_context.MenuCategoryItems.Any(rel => rel.ItemId == item.Id && rel.MenuCategoryId == category.Id))
                {
                    var newRelation = new MenuCategoryItem()
                    {
                        ItemId = item.Id,
                        MenuCategoryId = category.Id
                    };
                    _context.Insert(newRelation);
                }
            }

            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}