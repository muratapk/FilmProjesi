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
        //public  Context(DbContextOptions<Context>options):base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GRV4CB6\\SQLEXPRESS;Initial Catalog=FilmDb;Integrated Security=True;Trust Server Certificate=True");

           
        }

        public DbSet<Category>Categories { get; set; }
        public DbSet<Videos> Videos { get; set; }   
    }
}
