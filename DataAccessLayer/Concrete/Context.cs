using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public  Context(DbContextOptions<Context>options):base(options)
        {
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Videos> Videos { get; set; }   
    }
}
