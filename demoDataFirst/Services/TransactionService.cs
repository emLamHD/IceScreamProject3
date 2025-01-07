using demoDataFirst.Models;
using demoDataFirst.Repositories;

namespace demoDataFirst.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Transaction> _transactionRepository;

        public TransactionService(IGenericRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAll();
        }

        public Transaction GetTransactionById(int id)
        {
            return _transactionRepository.GetById(id);
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _transactionRepository.DeleteAsync(id);
        }
    }
}
