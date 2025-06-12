using Assignment_10._3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10._3.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Car> CarSet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=SILVERCOIN;" +
                "initial catalog=Assignment103Cars;" +
                "integrated security=True;" +
                "encrypt=False;" +
                "trustservercertificate=True;" +
                "MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car(vin: "1GNDT13S822155079", make: "Chevrolet", model:"Trailblazer 4WD", year:"2002", price: 3000),
                new Car(vin: "54DB4W1B3ES804414", make: "Isuzu", model:"NPR", year:"2014", price: 10000),
                new Car(vin: "1GCEC14X19Z270163", make: "Chevrolet", model:"Silverado 1500 2WD", year:"2009", price: 15005)
                );
        }
    }
}
