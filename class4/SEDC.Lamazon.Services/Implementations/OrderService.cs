using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain;
using SEDC.Lamazon.Mappers.Order;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        //private IRepository<User> _userRepository;
        //private IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository) // in order for the service to be instantiated, the repository is needed 
        {

            _orderRepository = orderRepository;
            //_userRepository = userRepository;
            //_productRepository = productRepository;
        }

        public List<OrderViewModel> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();
            List<OrderViewModel> viewModels = new List<OrderViewModel>();
            foreach (Order order in orders)
            {
                viewModels.Add(order.ToOrderViewModel());
            }

            // return orders.ToOrderDetailsViewModelList();

            return viewModels;
        }

        public OrderViewModel GetOrderById(int id)
        {
            Order order = _orderRepository.GetById(id);
            if (order == null)
            {
                //log the exception
                throw new Exception($"Order with id {id} does not exist!");
            }

            return order.ToOrderViewModel();
        }
    }
}
