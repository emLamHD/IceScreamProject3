using demoDataFirst.Models;
using demoDataFirst.Repositories;
using System.Collections.Generic;

namespace demoDataFirst.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
            _orderRepository.Save();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            _orderRepository.Save();
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
            _orderRepository.Save();
        }
    }

   
}
