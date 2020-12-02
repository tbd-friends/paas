using System;
using System.Collections.Generic;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class AssociateItemWithCategory : IRequest
    {
        public Guid ItemUID { get; set; }
        public IEnumerable<Guid> CategoryUIDS { get; set; }

    }
}