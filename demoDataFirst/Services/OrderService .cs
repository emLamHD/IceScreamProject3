using demoDataFirst.Models;
using demoDataFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task CreateAsync(Order order)
        {
            // Kiểm tra nếu Order đã tồn tại (nếu có điều kiện cụ thể)
            var existingOrder = await _orderRepository.GetByConditionAsync(o => o.OrderId == order.OrderId);
            if (existingOrder != null)
            {
                throw new Exception("Order already exists.");
            }

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
