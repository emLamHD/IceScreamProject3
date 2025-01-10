using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        Task CreateAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);

        Task<bool> UpdateAvatarAsync(int userId, string? avatarUrl);
        Task<User?> GetCurrentUserAsync(int userId);
    }
}