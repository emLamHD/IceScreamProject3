using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demoDataFirst.Data;
using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.CodeAnalysis.Scripting;
using demoDataFirst.DTO;
using BCrypt.Net;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IAuthService _authService;

        public TransactionsController(ITransactionService transactionService, IAuthService authService)
        {
            _transactionService = transactionService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactionById(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            try
            {
                await _transactionService.CreateAsync(transaction);
                return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id, Transaction transaction)
        {
            if (id != transaction.TransactionId) return BadRequest();

            _transactionService.UpdateTransactionAsync(transaction);
            return Ok("Transaction updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            await _transactionService.DeleteTransactionAsync(id);  // Gọi phương thức DeleteTransactionAsync bất đồng bộ
            return Ok("Transaction deleted successfully");  // Trả về Ok khi xóa thành công
        }
    }
}
