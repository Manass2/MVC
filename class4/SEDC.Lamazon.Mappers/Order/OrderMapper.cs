using SEDC.Lamazon.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.Mappers.Order
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this SEDC.Lamazon.Domain.Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Status = order.Status,
                UserName = order.User.Username,
                UserFullname = order.User.FullName,
                ProductNames = order.ProductOrders.Select(x => x.Product.Name).ToList(),
                Price = order.ProductOrders.Select(x => x.Product.Price).ToList().Sum()
            };
        }
    }
}
