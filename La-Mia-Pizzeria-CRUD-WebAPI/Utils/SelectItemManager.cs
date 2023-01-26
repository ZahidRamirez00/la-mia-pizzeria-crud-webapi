using La_Mia_Pizzeria_CRUD_WebAPI.DataBase;
using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Utils
{
    public static class SelectItemManager
    {
        public static List<SelectListItem> ConverterListIngredient()
        {
            using PizzaContext db = new();
            List<SelectListItem> list = new();
            foreach(Ingrediente ingrediente in db.Ingredienti)
            {
                SelectListItem Item = new() { Text=ingrediente.Nome, Value=ingrediente.IngredienteId.ToString()};
                list.Add(Item);
            }
            return list;
        }
    }
}
