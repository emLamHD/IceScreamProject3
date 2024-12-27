using demoDataFirst.Models;
using demoDataFirst.Repositories;
using System.Collections.Generic;

namespace demoDataFirst.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;

        public OrderDetailService(IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailRepository.GetAll();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _orderDetailRepository.GetById(id);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderDetail);
            _orderDetailRepository.Save();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
            _orderDetailRepository.Save();
        }

        public void DeleteOrderDetail(int id)
        {
            _orderDetailRepository.Delete(id);
            _orderDetailRepository.Save();
        }
    }


}
