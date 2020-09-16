using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List<PizzaViewModel> pizzaViewModels = _pizzaService.GetAllPizzas();
            return View(pizzaViewModels);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                PizzaViewModel orderDetailsViewModel = _pizzaService.GetPizzaById(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception ex)
            {
                return View("ExceptionView");
            }
        }
        [HttpGet]
        public IActionResult CreatePizza()
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();
            return View(pizzaViewModel);
        }
        [HttpPost]
        public IActionResult CreatePizzaPost(PizzaViewModel pizzaView)
        {
           
            try
            {
                _pizzaService.CreatePizza(pizzaView);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionView");
            }
        }
    }
}
