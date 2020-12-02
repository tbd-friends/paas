#nullable enable
using System;
using System.Collections.Generic;
using MediatR;

namespace Gamer.Menu.Application.Commands
{
    public class CreateAndAssociateItemWithCategory : IRequest
    {
        public CreateAndAssociateItemWithCategory()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<Guid>? CategoryIds { get; set; }
    }
}