using demoDataFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace demoDataFirst.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IceScreamProject3Context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(IceScreamProject3Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync(); // Trả về danh sách các thực thể
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity); // Gắn thực thể vào DbSet
            _context.Entry(entity).State = EntityState.Modified; // Đánh dấu thực thể là "Modified"
            await _context.SaveChangesAsync(); // Lưu thay đổi xuống cơ sở dữ liệu
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);  // Tìm kiếm entity bất đồng bộ
            if (entity != null)
            {
                _dbSet.Remove(entity);  // Xóa entity
                await _context.SaveChangesAsync();  // Lưu thay đổi bất đồng bộ
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }


    }
}
