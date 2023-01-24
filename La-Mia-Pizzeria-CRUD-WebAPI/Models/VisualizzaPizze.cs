using La_Mia_Pizzeria_CRUD_WebAPI.Models;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Models
{
    public class VisualizzaPizze
    {
        public Pizza PizzaSelezionata { get; set; }
        public List<Categoria>? ListaCategorie { get; set; }
    }
}
