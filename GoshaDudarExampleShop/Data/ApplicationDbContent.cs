using GoshaDudarExampleShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GoshaDudarExampleShop.Data
{
    public class ApplicationDbContent : DbContext
    {
        public ApplicationDbContent(DbContextOptions<ApplicationDbContent> options) : base(options)
        {
        }        
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        
        public DbSet<ShopCart> ShopCart { get; set; }
        
        
    }
}