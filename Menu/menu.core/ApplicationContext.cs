using System.Linq;
using Gamer.Menu.Core.Models;
using Microsoft.EntityFrameworkCore;
using ModelMenu = Gamer.Menu.Core.Models.Menu;

namespace Gamer.Menu.Core
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ModelMenu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuCategoryItem> MenuCategoryItems { get; set; }

        IQueryable<Category> IApplicationContext.Categories => Categories;
        IQueryable<Item> IApplicationContext.Items => Items;
        IQueryable<ModelMenu> IApplicationContext.Menus => Menus;
        IQueryable<MenuCategory> IApplicationContext.MenuCategories => MenuCategories;
        IQueryable<MenuCategoryItem> IApplicationContext.MenuCategoryItems => MenuCategoryItems;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ModelMenu>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<ModelMenu>()
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Category>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Category>()
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Item>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Item>()
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<MenuCategory>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<MenuCategory>()
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<MenuCategoryItem>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<MenuCategoryItem>()
                .Property(p => p.Id)
                .HasDefaultValueSql("newid()");
        }

        void IApplicationContext.Insert<TEntity>(TEntity entity)
        {
            Add(entity);
        }

        void IApplicationContext.Delete<TEntity>(TEntity entity)
        {
            Remove(entity);
        }

        void IApplicationContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}