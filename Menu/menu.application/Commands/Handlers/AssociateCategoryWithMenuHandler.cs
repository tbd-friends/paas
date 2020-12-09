using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gamer.Menu.Core;
using Gamer.Menu.Core.Models;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class AssociateCategoryWithMenuHandler : AsyncRequestHandler<AssociateCategoryWithMenu>
    {
        private readonly IApplicationContext _context;

        public AssociateCategoryWithMenuHandler(IApplicationContext context)
        {
            _context = context;
        }

        protected override Task Handle(AssociateCategoryWithMenu request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(c => c.UID == request.CategoryUID);
            foreach (var menuId in request.MenuUIDS)
            {
                var menu = _context.Menus.FirstOrDefault(m => m.UID == menuId);
                if (!_context.MenuCategories.Any(rel => rel.CategoryId == category.Id && rel.MenuId == menu.Id))
                {
                    var newRelation = new MenuCategory
                    {
                        CategoryId = category.Id,
                        MenuId = menu.Id
                    };
                    _context.Insert(newRelation);
                }
            }

            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}