using CoreFitness.Application.Interfaces;
using CoreFitness.Domain.Entities;
using CoreFitness.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Infrastructure.Repositories;

public class MembershipRepository : IMembershipRepository
{
    private readonly CoreFitnessDbContext _context;

    public MembershipRepository(CoreFitnessDbContext context)
    {
        _context = context;
    }

    public async Task<Membership?> GetByUserIdAsync(string userId)
        => await _context.Memberships.FirstOrDefaultAsync(m => m.UserId == userId);

    public async Task<Membership?> GetByIdAsync(int id)
        => await _context.Memberships.FindAsync(id);

    public async Task AddAsync(Membership membership)
    {
        _context.Memberships.Add(membership);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Membership membership)
    {
        _context.Memberships.Update(membership);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Membership membership)
    {
        _context.Memberships.Remove(membership);
        await _context.SaveChangesAsync();
    }
}
