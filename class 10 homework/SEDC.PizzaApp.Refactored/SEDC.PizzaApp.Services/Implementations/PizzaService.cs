using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Pizza;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class PizzaService: IPizzaService
    {
        private IPizzaRepository _pizzaRepository;
        private IRepository<Order> _orderRepository;

        public PizzaService(IPizzaRepository pizzaRepository, IRepository<Order> orderRepository)
        {
            _pizzaRepository = pizzaRepository ;
            _orderRepository = orderRepository;
        }
        public List<PizzaDDViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzas = _pizzaRepository.GetAll();
            List<PizzaDDViewModel> pizzaDdViewModels = new List<PizzaDDViewModel>();
            foreach (Pizza pizza in pizzas)
            {
                pizzaDdViewModels.Add(pizza.ToPizzaDdViewModel());
            }

            return pizzaDdViewModels;
        }

        public string GetMostPopularPizza()
        {
            List<Order> ordersDb = _orderRepository.GetAll();
            List<PizzaOrder> pizzaOrders = ordersDb.SelectMany(x => x.PizzaOrders).ToList(); //get all pizza orders in one list

            return pizzaOrders.GroupBy(x => x.PizzaId) //group by pizza
                .OrderByDescending(x => x.Count()) // sort by number of pizza orders
                .First() // group of pizza orders
                .Select(x => x.Pizza.Name)
                .First();
        }

        public string GetPizzaOnPromotion()
        {
            Pizza pizzaOnPromotion = _pizzaRepository.GetPizzaOnPromotion();
            return pizzaOnPromotion != null ? pizzaOnPromotion.Name : string.Empty;
        }

        public List<PizzaViewModel> GetAllPizzas()
        {
            List<Pizza> pizzas = _pizzaRepository.GetAll();

            return pizzas.ToPizzaViewModelList();
        }

        public PizzaViewModel GetPizzaById(int id)
        {
            Pizza pizza = _pizzaRepository.GetById(id);
            if (pizza == null)
            {
                //log the exception
                throw new Exception($"Pizza with id {id} does not exist!");
            }

            return pizza.ToPizzaViewModel();
        }

        public bool PizzaPromotionValidation()
        {
            List<Pizza> pizzas = _pizzaRepository.GetAll();
            bool promotion = false;
            foreach (Pizza pizza in pizzas)
            {
                if (pizza.IsOnPromotion == true)
                {
                    promotion = true;
                }
            }
            return promotion;
        }

        public void CreatePizza(PizzaViewModel pizzaViewModel)
        {
            Pizza pizza = pizzaViewModel.ToPizza();


            int pizzaId = _pizzaRepository.Insert(pizza);
            if (pizzaId <= 0)
            {
                throw new Exception("Something went wrong while saving the new pizza");
            }
        }
    }
}
