using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Order() { }
        public Order(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
