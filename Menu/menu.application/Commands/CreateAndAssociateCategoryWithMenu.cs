#nullable enable
using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;

namespace Gamer.Menu.Application.Commands
{
    public class CreateAndAssociateCategoryWithMenu : IRequest
    {
        public CreateAndAssociateCategoryWithMenu()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }

        public List<Guid>? MenuIds { get; set; }
    }
}