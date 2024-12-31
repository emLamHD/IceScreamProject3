using demoDataFirst.Models;
using demoDataFirst.Repositories;

namespace demoDataFirst.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public async Task CreateAsync(User user)
        {
            // Kiểm tra email trùng lặp
            var existingUser = await _userRepository.GetByConditionAsync(u => u.Email == user.Email);
            if (existingUser != null) // Chỉ cần kiểm tra khác null
            {
                throw new Exception("Email đã tồn tại.");
            }

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }


        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            _userRepository.SaveAsync();
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
            _userRepository.SaveAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByConditionAsync(u => u.Email == email);
        }

    }
}
