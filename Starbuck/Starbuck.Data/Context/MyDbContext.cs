using Microsoft.EntityFrameworkCore;
using System.Linq;
using Starbuck.Business.Models;

namespace Starbuck.Data.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Extra> Extras { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

       

    }
}
