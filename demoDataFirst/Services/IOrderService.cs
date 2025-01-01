using demoDataFirst.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demoDataFirst.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        Task CreateAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
