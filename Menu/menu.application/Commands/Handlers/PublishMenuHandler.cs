using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Gamer.Menu.Application.Commands.Publishing;
using Gamer.Menu.Core;
using kafka.shared.Serializers;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Gamer.Menu.Application.Commands.Handlers
{
    public class PublishMenuHandler : IRequestHandler<PublishMenu>
    {
        private readonly IDictionary<string, string> _kafkaConfiguration;
        private readonly IApplicationContext _context;

        public PublishMenuHandler(IConfiguration configuration, IApplicationContext context)
        {
            _kafkaConfiguration = new Dictionary<string, string>();

            configuration
                .GetSection("kafka:producer")
                .Bind(_kafkaConfiguration);

            _context = context;
        }

        public async Task<Unit> Handle(PublishMenu request, CancellationToken cancellationToken)
        {
            using var producer = new ProducerBuilder<Guid, PublishedMenu>(_kafkaConfiguration)
                .SetKeySerializer(new GuidKeySerializer())
                .SetValueSerializer(new JsonValueSerializer<PublishedMenu>())
                .Build();

            var menu = (from x in _context.Menus
                        where x.UID == request.Id
                        select new PublishedMenu
                        {
                            Id = x.UID,
                            Name = x.Name,
                            Categories = (from mc in _context.MenuCategories
                                          join c in _context.Categories on mc.CategoryId equals c.Id
                                          where mc.MenuId == x.Id
                                          select new PublishedCategory
                                          {
                                              Id = c.UID,
                                              Name = c.Name,
                                              Items = (from mi in _context.MenuCategoryItems
                                                       join i in _context.Items on mi.ItemId equals i.Id
                                                       where mi.MenuCategoryId == mc.CategoryId
                                                       select new PublishedItem
                                                       {
                                                           Id = i.UID,
                                                           Name = i.Name,
                                                           Description = i.Description,
                                                           Price = i.Price
                                                       }).ToList()
                                          }).ToList()
                        }).SingleOrDefault();

            if (menu != null)
            {
                await producer.ProduceAsync("menus", new Message<Guid, PublishedMenu>
                {
                    Key = request.Id,
                    Value = menu
                }, cancellationToken);
            }

            return Unit.Value;
        }
    }
}