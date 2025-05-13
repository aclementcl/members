using Club.Infrastructure.Data;
using Club.Domain.Models;
using Club.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club.Infrastructure.Repository;

public class MemberRepository : Repository<Member>, IMemberRepository
{
    public MemberRepository(ClubContext context) : base(context) { }

    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task<Member?> GetByMemberIdAsync(int id)
    {
        return await _context.Members.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Member member)
    {
        await _context.Members.AddAsync(member);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Member member)
    {
        _context.Members.Update(member);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var member = await GetByMemberIdAsync(id);
        if (member != null)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
    }
}