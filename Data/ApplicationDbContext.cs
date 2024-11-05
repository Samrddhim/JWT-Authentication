using CRUDapplicationUsingLayers2.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDapplicationUsingLayers2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books{ get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
