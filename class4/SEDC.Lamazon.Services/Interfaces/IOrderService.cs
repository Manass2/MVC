using SEDC.Lamazon.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
    }
}
