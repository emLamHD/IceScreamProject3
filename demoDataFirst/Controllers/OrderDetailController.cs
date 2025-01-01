using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public IActionResult GetAllOrderDetails()
        {
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            var orderDetail = _orderDetailService.GetOrderDetailById(id);
            if (orderDetail == null) return NotFound();
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                await _orderDetailService.CreateOrderDetailAsync(orderDetail);
                return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetail.OrderDetailId }, orderDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailId) return BadRequest("OrderDetail ID không khớp.");

            await _orderDetailService.UpdateOrderDetailAsync(orderDetail);
            return Ok("Cập nhật thành công.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _orderDetailService.DeleteOrderDetailAsync(id);
            return Ok("Xóa thành công.");
        }
    }
}
