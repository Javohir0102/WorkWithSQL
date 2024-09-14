using ControleStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleStorage.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
