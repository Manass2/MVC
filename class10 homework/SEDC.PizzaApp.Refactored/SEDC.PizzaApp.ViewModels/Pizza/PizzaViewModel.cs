using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEDC.PizzaApp.ViewModels.Pizza
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Is this Pizza on promotion?")]
        public bool IsOnPromotion { get; set; }
    }
}
