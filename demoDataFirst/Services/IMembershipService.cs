using demoDataFirst.Models;

namespace demoDataFirst.Services
{
    public interface IMembershipService
    {
        IEnumerable<Membership> GetAllMemberships();
        Membership GetMembershipById(int id);
        Task CreateAsync(Membership membership);
        Task UpdateMembershipAsync(Membership membership);
        Task DeleteMembershipAsync(int id);
        Task<Membership?> GetMembershipByUserIdAsync(int? usesrId);
    }
}
