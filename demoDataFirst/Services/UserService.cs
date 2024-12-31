using demoDataFirst.Models;
using demoDataFirst.Repositories;
using Microsoft.AspNetCore.Identity;

namespace demoDataFirst.Services
{
    public class UserService(IGenericRepository<User> userRepository) : IUserService
    {
        private readonly IGenericRepository<User> _userRepository = userRepository;

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
