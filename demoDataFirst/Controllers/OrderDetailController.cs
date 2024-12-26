using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDetail> GetOrderDetailById(int id)
        {
            var orderDetail = _orderDetailService.GetOrderDetailById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public ActionResult AddOrderDetail([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _orderDetailService.AddOrderDetail(orderDetail);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetail.OrderDetailId }, orderDetail);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderDetail(int id, [FromBody] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailId)
            {
                return BadRequest("OrderDetail ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _orderDetailService.UpdateOrderDetail(orderDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderDetail(int id)
        {
            var existingOrderDetail = _orderDetailService.GetOrderDetailById(id);
            if (existingOrderDetail == null)
            {
                return NotFound();
            }

            _orderDetailService.DeleteOrderDetail(id);
            return NoContent();
        }
    }
}
