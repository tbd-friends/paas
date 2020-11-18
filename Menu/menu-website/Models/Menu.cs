using System.Collections.Generic;
using Confluent.Kafka;
using Gamer.Menu.Website.Serializers;

namespace kafka.consumers.Models
{
    public class Menu
    {
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }

    public async Task CreateMenu()
    {
        var configuration = new Dictionary<string, string>()
        {
            {"bootstrap.servers", "localhost:9092"}
        };

        using var producer = new ProducerBuilder<Guid, Menu>(configuration)
            .SetKeySerializer(new GuidKeySerializer())
            .SetValueSerializer(new JsonValueSerializer<Menu>()).Build();

        await producer.ProduceAsync("menus", new Message<Guid, Menu>()
        {
            Key = Guid.NewGuid(),
            Value = new Menu
            {
                Name = Model.Name,
                Categories = new[]
                {
                    new Category()
                    {
                        Name = "Appetizers", Items = new[]
                        {
                            new Item() {Name = "Mozzarella Sticks", Price = 9.99},
                            new Item() {Name = "Garlic Bread", Price = 6.99},
                            new Item() {Name = "Wings", Price = 12.99},
                        }
                    },
                    new Category()
                    {
                        Name = "Pizzas", Items = new[]
                        {
                            new Item() {Name = "Cheese", Price = 9.99},
                            new Item() {Name = "Pepperoni", Price = 10.99},
                            new Item() {Name = "Ham & Pineapple", Price = 19.99},
                        }
                    },
                }
            }
        });
    }
}