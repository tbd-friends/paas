using System;
using System.Linq;
using kafka.consumers.ConsumedModels;
using StorageMenu = interactions.models.Menu;
using StorageCategory = interactions.models.Category;
using StorageItem = interactions.models.Item;

namespace kafka.consumers.Infrastructure
{
    public static class ConsumerExtensions
    {
        public static StorageMenu TransformToStorageModel(this Menu menu)
        {
            return new StorageMenu
            {
                SourceMenuId = menu.Id,
                Name = menu.Name,
                Categories = from c in menu.Categories
                             select new StorageCategory
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Items = from i in c.Items
                                         select new StorageItem
                                         {
                                             Id = i.Id,
                                             Name = i.Name,
                                             Description = i.Description,
                                             Price = i.Price
                                         }
                             }
            };
        }
    }
}