using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        Task CreateAsync(User user);
        Task UpdateUserAsync(User user);
        void DeleteUser(int id);
        Task<User?> GetUserByEmailAsync(string email);
    }
}