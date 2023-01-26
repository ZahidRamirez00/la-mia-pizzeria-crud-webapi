using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Models
{
    public class Ingrediente
    {
        [Key]
        public int IngredienteId { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]
        public List<Pizza>? IngredientiPizza { get; set; }

        public Ingrediente() { }
    }
}
