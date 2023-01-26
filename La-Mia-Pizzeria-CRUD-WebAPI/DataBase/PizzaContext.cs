using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria_CRUD_WebAPI.DataBase
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }

        public DbSet<Categoria> Categorie { get; set; }

        public DbSet<Ingrediente> Ingredienti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzeriaDB"));
        }
    }
}
