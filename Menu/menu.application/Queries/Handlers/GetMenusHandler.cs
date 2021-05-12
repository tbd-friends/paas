using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gamer.Menu.Core;
using MediatR;
using menu.viewmodels;
using Microsoft.EntityFrameworkCore;

namespace Gamer.Menu.Application.Queries.Handlers
{
    public class GetMenusHandler : IRequestHandler<GetMenus, IEnumerable<MenuViewModel>>
    {
        private readonly IApplicationContext _context;

        public GetMenusHandler(IApplicationContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<MenuViewModel>> Handle(GetMenus request, CancellationToken cancellationToken)
        {
            var menus = from m in _context.Menus
                        select new MenuViewModel()
                        {
                            Uid = m.UID,
                            Name = m.Name,
                            Categories = from mc in _context.MenuCategories
                                         join c in _context.Categories on mc.CategoryId equals c.Id
                                         where mc.MenuId == m.Id
                                         select new MenuCategoryViewModel
                                         {
                                             Uid = c.UID,
                                             Name = c.Name,
                                             Items = from mi in _context.MenuCategoryItems
                                                     join i in _context.Items on mi.ItemId equals i.Id
                                                     select new MenuItemViewModel
                                                     {
                                                         Uid = i.UID,
                                                         Name = i.Name,
                                                         Description = i.Description,
                                                         Price = i.Price
                                                     }
                                         }
                        };

            return Task.FromResult(menus.AsEnumerable());
        }
    }
}