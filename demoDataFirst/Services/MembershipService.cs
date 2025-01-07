using demoDataFirst.Models;
using demoDataFirst.Repositories;

namespace demoDataFirst.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IGenericRepository<Membership> _membershipRepository;

        public MembershipService(IGenericRepository<Membership> membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return _membershipRepository.GetAll();
        }

        public Membership GetMembershipById(int id)
        {
            return _membershipRepository.GetById(id);
        }

        public async Task CreateMembershipAsync(Membership membership)
        {
            await _membershipRepository.AddAsync(membership);
            await _membershipRepository.SaveAsync();
        }

        public async Task UpdateMembershipAsync(Membership membership)
        {
            await _membershipRepository.UpdateAsync(membership);
        }

        public async Task DeleteMembershipAsync(int id)
        {
            await _membershipRepository.DeleteAsync(id);
        }
    }
}
