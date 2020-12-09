using System;
using System.Collections.Generic;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class AssociateCategoryWithMenu : IRequest
    {
        public Guid CategoryUID { get; set; }
        public IEnumerable<Guid> MenuUIDS { get; set; }
    }
}