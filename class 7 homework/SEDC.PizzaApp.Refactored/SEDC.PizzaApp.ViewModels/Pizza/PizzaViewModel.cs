using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.ViewModels.Pizza
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnPromotion { get; set; }
        //public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
