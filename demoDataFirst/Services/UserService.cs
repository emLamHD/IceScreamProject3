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

        public void AddUser(User user)
        {
            // Thêm logic nghiệp vụ nếu cần, ví dụ: kiểm tra email trùng lặp
            if (_userRepository.Find(u => u.Email == user.Email).Any())
            {
                throw new Exception("Email đã tồn tại.");
            }

            _userRepository.Add(user);
            _userRepository.Save();
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
        }
    }
}
