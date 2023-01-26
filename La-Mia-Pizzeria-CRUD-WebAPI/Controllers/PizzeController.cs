using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using La_Mia_Pizzeria_CRUD_WebAPI.DataBase;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzeController : ControllerBase
    {

        [HttpGet]

        public IActionResult Get(string? search)
        {
            using PizzaContext db = new();
            List<Pizza> listaPizze = new();
            if(search is null || search == "")
            {
                listaPizze = db.Pizze.Include(Pizza => Pizza.Ingredienti).ToList();
            }
            else
            {
                search = search.ToLower();
                listaPizze = db.Pizze.Include(Pizza => Pizza.Ingredienti)
                                     .Where(Pizza => Pizza.Nome.ToLower().Contains(search) || Pizza.Ingredienti.Any(Ingrediente => Ingrediente.Nome.ToLower().Contains(search)) || Pizza.CategoriaNome.ToLower().Contains(search) || Pizza.Descrizione.ToLower().Contains(search))
                                     .ToList();
            }
            return Ok(listaPizze);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using PizzaContext db = new();
            Pizza Pizza = db.Pizze.Where(Pizza => Pizza.Id == id).Include(Pizza => Pizza.Ingredienti).FirstOrDefault();
            if(Pizza is null)
            {
                return NotFound("La pizza che stai cercando non c'è.");
            }
            return Ok(Pizza);
        }
    }
}
