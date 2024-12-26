using demoDataFirst.Models;
using System.Collections.Generic;

namespace demoDataFirst.Repositories
{
    public interface IMembershipRepository : IGenericRepository<Membership>
    {
        IEnumerable<Membership> GetByUserId(int userId);

        IEnumerable<Membership> GetByType(string type);
        void Add(Membership membership);

        Membership GetById(int membershipId);

        void Update(Membership membership);

        void Delete(int membershipId);

        IEnumerable<Membership> GetAll();
    }
}