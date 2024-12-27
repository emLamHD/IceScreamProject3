using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailById(int id);
        void AddOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(int id);
    }
}
