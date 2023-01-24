using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Models
{
    [Table("Pizza")]
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string Immagine { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public Pizza()
        {

        }

        public Pizza(string nome, string prezzo, string descrizione, string immagine)
        {
            this.Nome = nome;
            this.Prezzo = prezzo;
            this.Descrizione = descrizione;
            this.Immagine = immagine;
        }
    }
}

