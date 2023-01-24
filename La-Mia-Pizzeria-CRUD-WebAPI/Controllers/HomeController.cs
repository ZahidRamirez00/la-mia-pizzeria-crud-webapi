using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using La_Mia_Pizzeria_CRUD_WebAPI.Models;
using La_Mia_Pizzeria_CRUD_WebAPI.DataBase;
using System.Diagnostics;

namespace La_Mia_Pizzeria_CRUD_WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PizzaContext db = new PizzaContext();
            List<Pizza> listaPizze = db.Pizzas.ToList();
            return View(listaPizze);
        }

        public IActionResult Dettagli(int id)
        {
            PizzaContext db = new PizzaContext();
            Pizza pizza = (from p in db.Pizzas where p.Id == id select p).Include(pizza => pizza.Categoria).FirstOrDefault();
            if (pizza == null)
            {
                return NotFound();
            }
            else
            {
                return View("Dettagli", pizza);
            }
        }

        public IActionResult Modifica(int id)
        {
            PizzaContext db = new PizzaContext();
            Pizza pizza = (from p in db.Pizzas where p.Id == id select p).FirstOrDefault();
            if (pizza == null)
            {
                return NotFound();
            }
            else
            {
                VisualizzaPizze PizzaDaModificare = new VisualizzaPizze();
                PizzaDaModificare.PizzaSelezionata = pizza;
                List<Categoria> ListaScelta = db.Categorie.ToList();
                PizzaDaModificare.ListaCategorie = ListaScelta;
                return View("Modifica", PizzaDaModificare);
            }
        }

        [HttpGet]
        public IActionResult FormAddPizza()
        {
            PizzaContext db = new PizzaContext();
            VisualizzaPizze PizzaDaModificare = new VisualizzaPizze();
            PizzaDaModificare.PizzaSelezionata = new Pizza();
            List<Categoria> ListaScelta = db.Categorie.ToList();
            PizzaDaModificare.ListaCategorie = ListaScelta;
            return View("FormPizza", PizzaDaModificare);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormAddPizza(VisualizzaPizze formData)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPizza");
            }
            PizzaContext db = new PizzaContext();
            db.Pizzas.Add(formData.PizzaSelezionata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormEditPizza(VisualizzaPizze formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Modifica");
            }
            PizzaContext db = new PizzaContext();
            Pizza pizza = (from p in db.Pizzas where p.Id == formData.PizzaSelezionata.Id select p).FirstOrDefault();
            pizza.Nome = formData.PizzaSelezionata.Nome;
            pizza.Prezzo = formData.PizzaSelezionata.Prezzo;
            pizza.Descrizione = formData.PizzaSelezionata.Descrizione;
            pizza.Immagine = formData.PizzaSelezionata.Immagine;
            pizza.CategoriaId = formData.PizzaSelezionata.CategoriaId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeletePizza(int id)
        {
            PizzaContext db = new PizzaContext();
            Pizza pizza = (from p in db.Pizzas where p.Id == id select p).FirstOrDefault();
            db.Remove(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}