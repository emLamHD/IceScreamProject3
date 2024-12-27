using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using demoDataFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace demoDataFirst.Repositories
{
    public class MembershipRepository : GenericRepository<Membership>, IGenericRepository<Membership>
    {
        private readonly DbContext _context;

        public MembershipRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Membership> GetAll()
        {
            return _context.Set<Membership>().ToList();
        }

        public Membership GetById(object id)
        {
            return _context.Set<Membership>().Find(id);
        }

        public IEnumerable<Membership> Find(Expression<Func<Membership, bool>> predicate)
        {
            return _context.Set<Membership>().Where(predicate).ToList();
        }

        public void Add(Membership entity)
        {
            _context.Set<Membership>().Add(entity);
        }

        public void Update(Membership entity)
        {
            _context.Set<Membership>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Set<Membership>().Remove(entity);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Membership> GetByUserId(int userId)
        {
            return _context.Set<Membership>().Where(m => m.UserId == userId).ToList();
        }

        public IEnumerable<Membership> GetByType(string type)
        {
            return _context.Set<Membership>().Where(m => m.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}