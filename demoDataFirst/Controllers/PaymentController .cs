using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Payment>> GetAllPayments()
        {
            var payments = _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public ActionResult<Payment> GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public ActionResult AddPayment([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _paymentService.AddPayment(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentId }, payment);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePayment(int id, [FromBody] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return BadRequest("Payment ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _paymentService.UpdatePayment(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePayment(int id)
        {
            var existingPayment = _paymentService.GetPaymentById(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            _paymentService.DeletePayment(id);
            return NoContent();
        }
    }
}
