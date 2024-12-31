using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        Task<User?> Authenticate(string email, string password);
    }

}
