using System.Collections;
using System.Collections.Generic;
using MediatR;
using menu.viewmodels;

namespace Gamer.Menu.Application.Queries
{
    public class GetMenus : IRequest<IEnumerable<MenuViewModel>>
    {
        
    }
}