using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using La_Mia_Pizzeria_CRUD_WebAPI.DataBase;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzeController : ControllerBase
    {

        [HttpGet]

        public IActionResult Get()
        {
            PizzaContext db = new PizzaContext();
            List<Pizza> listaPizze = db.Pizzas.ToList();
            return Ok(listaPizze);
        }
    }
}
