using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class CreateAndAssociateCategoryWithMenuHandler : AsyncRequestHandler<CreateAndAssociateCategoryWithMenu>
    {
        private readonly IMediator _mediator;

        public CreateAndAssociateCategoryWithMenuHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override async Task Handle(CreateAndAssociateCategoryWithMenu request, CancellationToken cancellationToken)
        {
            var newCategoryUId = await _mediator.Send(new CreateCategory { Name = request.Name }, cancellationToken);
            if (request.MenuIds != null && request.MenuIds.Any())
            {
                await _mediator.Send(new AssociateCategoryWithMenu
                {
                    CategoryUID = newCategoryUId,
                    MenuUIDS = request.MenuIds
                }, cancellationToken);
            }
        }
    }
}