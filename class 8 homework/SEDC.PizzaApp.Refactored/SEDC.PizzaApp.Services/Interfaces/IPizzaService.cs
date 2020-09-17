using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaDDViewModel> GetPizzasForDropdown();
        string GetMostPopularPizza();
        string GetPizzaOnPromotion();
        List<PizzaViewModel> GetAllPizzas();
        PizzaViewModel GetPizzaById(int value);
        void CreatePizza(PizzaViewModel pizzaViewModel);
        bool PizzaPromotionValidation();
    }
}
