using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria_CRUD_WebAPI.DataBase
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Categoria> Categorie { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzeriaDB;Integrated Security=True;TrustServerCertificate=True");

        }
    }
}
