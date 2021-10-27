using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Lamanzon.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService) // we are using Dependency Injection - needs to instantiate the service
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            List<OrderViewModel> orderViewModels = _orderService.GetAllOrders();
            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                OrderViewModel orderViewModel = _orderService.GetOrderById(id.Value);
                return View(orderViewModel);
            }
            catch (Exception ex)
            {
                return View("ExceptionView");
            }
        }
    }
}
