using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateAndAssociateItemWithCategoryHandler : AsyncRequestHandler<CreateAndAssociateItemWithCategory>
    {
        private readonly IMediator _mediator;

        public CreateAndAssociateItemWithCategoryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async Task Handle(CreateAndAssociateItemWithCategory request, CancellationToken cancellationToken)
        {
            var newItemUId = await _mediator.Send(new CreateItem
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            }, cancellationToken);

            if (request.CategoryIds != null && request.CategoryIds.Any())
            {
                await _mediator.Send(new AssociateItemWithCategory
                {
                    ItemUID = newItemUId,
                    CategoryUIDS = request.CategoryIds
                }, cancellationToken);
            }
        }
    }
}