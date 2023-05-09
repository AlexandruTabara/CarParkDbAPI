using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkDbAPI.Models
{
    internal class CarDBContext : DbContext
    {
        public DbSet<Autovehicul> Autovehicule { get; set; }
        public DbSet<Cheie> Chei { get; set; }
        public DbSet<CarteTehnica> CartiTehnice { get; set; }
        public DbSet<Producator> Producatori { get; set; }
        public CarDBContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\otiot\source\repos\CarParkDbAPI\CarParkDbAPI\Cars.mdf;Integrated Security=True");
        }
    }
}
