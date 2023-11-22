using EmpSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpSystem.DAL.Database
{
    public class DbContainer : DbContext
    {

        public DbContainer(DbContextOptions<DbContainer> opts ):base(opts)
        {
            
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=. ; database= SharpDb ;integrated security = true ;Encrypt=False");
        //}
    }
} 
