using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetAllTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactionById(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public ActionResult AddTransaction([FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _transactionService.AddTransaction(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTransaction(int id, [FromBody] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest("Transaction ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _transactionService.UpdateTransaction(transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTransaction(int id)
        {
            var existingTransaction = _transactionService.GetTransactionById(id);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            _transactionService.DeleteTransaction(id);
            return NoContent();
        }
    }
}
