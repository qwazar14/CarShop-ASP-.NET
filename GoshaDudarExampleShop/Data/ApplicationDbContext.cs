using GoshaDudarExampleShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GoshaDudarExampleShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }        
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        
        
    }
}