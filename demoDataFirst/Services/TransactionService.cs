using demoDataFirst.Repositories;
using demoDataFirst.Models;

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

        public async Task CreateAsync(Transaction transaction)
        {
            // sẽ xây dựng logic sau...

            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            _transactionRepository.UpdateAsync(transaction); // Cập nhật thông tin transaction
            await _transactionRepository.SaveAsync(); // Lưu thay đổi xuống cơ sở dữ liệu
        }

        public async Task DeleteTransactionAsync(int id)
        {
            await _transactionRepository.DeleteAsync(id);  // Gọi phương thức DeleteAsync của repository để xóa người dùng
        }

        public async Task<Transaction?> GetTransactionByUserIdAsync(int userId)
        {
            return await _transactionRepository.GetByConditionAsync(u => u.UserId == userId);
        }
    }
}
