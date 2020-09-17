using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.ViewModels.Feedback;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Mappers.Pizza
{
    public static class PizzaMapper
    {
        public static PizzaDDViewModel ToPizzaDdViewModel(this Domain.Models.Pizza pizza)
        {
            return new PizzaDDViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name
            };
        }

        public static PizzaViewModel ToPizzaViewModel(this Domain.Models.Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                IsOnPromotion = pizza.IsOnPromotion
            };
        }

        public static Domain.Models.Pizza ToPizza(this PizzaViewModel pizzaViewModel)
        {

            return new Domain.Models.Pizza
            {
                Id = pizzaViewModel.Id,
                Name = pizzaViewModel.Name,
                IsOnPromotion = pizzaViewModel.IsOnPromotion
            };
        }

        public static List<PizzaViewModel> ToPizzaViewModelList(this List<Domain.Models.Pizza> pizzas)
        {
            List<PizzaViewModel> viewModels = new List<PizzaViewModel>();
            foreach (Domain.Models.Pizza order in pizzas)
            {
                viewModels.Add(order.ToPizzaViewModel());
            }

            return viewModels;
        }


    }
}
