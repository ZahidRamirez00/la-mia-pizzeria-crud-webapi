using Azure;
using La_Mia_Pizzeria_CRUD_WebAPI.DataBase;
using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using La_Mia_Pizzeria_CRUD_WebAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza>? ListaPizze = db.Pizze.Where(p => p.Categoria.NomeCategoria == "Pizze Speciali").ToList<Pizza>();

                return View("Index", ListaPizze);
            }
        }

        [Authorize]
        public IActionResult LeNostrePizzeAdmin()
    }
}
