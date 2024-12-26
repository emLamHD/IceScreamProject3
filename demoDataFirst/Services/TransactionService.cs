using demoDataFirst.Models;
using demoDataFirst.Repositories;
using System.Collections.Generic;

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

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
            _transactionRepository.Save();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _transactionRepository.Update(transaction);
            _transactionRepository.Save();
        }

        public void DeleteTransaction(int id)
        {
            _transactionRepository.Delete(id);
            _transactionRepository.Save();
        }
    }

    
}
