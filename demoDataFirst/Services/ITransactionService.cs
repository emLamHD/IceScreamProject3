using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        Task CreateAsync(Transaction transaction);
        Task UpdateTransactionAsync(Transaction transaction);
        Task DeleteTransactionAsync(int id);
        Task<Transaction?> GetTransactionByUserIdAsync(int userId);
    }
}
