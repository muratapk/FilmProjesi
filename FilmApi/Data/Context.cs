using FilmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Videos> Videos { get; set; }
    }
}
