using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using La_Mia_Pizzeria_CRUD_WebAPI.Models;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Models
{
    [Table("Categorie")]
    public class Categoria
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        public List<Pizza>? Pizzas { get; set; }


        public Categoria()
        {

        }

        public Categoria(int id, string nomeCategoria)
        {
            this.Id = id;
            this.NomeCategoria = nomeCategoria;
        }
    }
}

