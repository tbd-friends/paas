
namespace kafka.consumers.Models
{
    ArrayList<Item, Category> currentMenu;
    public class Menu
    {
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }

    public void CreateMenu()
    {
        
        currentMenu.push(
            new Category(){Name = "Appetizers", 
            new Item() {Name = "Mozzarella Sticks", Price = 9.99}
        )

        currentMenu.push(
            new Category(){Name = "Appetizers", 
            new Item() {Name = "Garlic Bread", Price = 9.99}
        )

        currentMenu.push(
            new Category(){Name = "Appetizers", 
            new Item() {Name = "Wings", Price = 9.99}
        )
        
    }

    public void PublishMenu()
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
            Value = currentMenu
        };
    }

}