using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Gamer.Menu.Core.Models;
using MenuModel = Gamer.Menu.Core.Models.Menu;

namespace Gamer.Menu.Core
{
    public interface IApplicationContext
    {
        IQueryable<Category> Categories { get; }
        IQueryable<Item> Items { get; }
        IQueryable<MenuModel> Menus { get; }
        IQueryable<MenuCategory> MenuCategories { get; }
        IQueryable<MenuCategoryItem> MenuCategoryItems { get; }

        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void SaveChanges();
    }
}