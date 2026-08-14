using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Web.Data
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly ApplicationDbContext _context;

        public MembershipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Membership?> GetMembershipByUserIdAsync(string userId)
        {
            return await _context.Memberships
                .FirstOrDefaultAsync(m => m.UserId == userId);
        }

        public async Task AddAsync(Membership membership)
        {
            _context.Memberships.Add(membership);
            await _context.SaveChangesAsync();
        }
    }
}
