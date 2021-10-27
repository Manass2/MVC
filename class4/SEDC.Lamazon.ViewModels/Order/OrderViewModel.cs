using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.ViewModels.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string UserFullname { get; set; }
        public List<string> ProductNames { get; set; }
        public double Price { get; set; }
    }
}
