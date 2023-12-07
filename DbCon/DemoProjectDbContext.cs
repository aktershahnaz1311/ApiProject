using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.DbCon
{
    public class DemoProjectDbContext : DbContext
    {
        public DemoProjectDbContext(DbContextOptions<DemoProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
      
       

        public DbSet<Country> Countrys { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

       
        public DbSet<Faculty> Faculties{ get; set; }










    }
}
