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

    public Task<Member?> GetByMemberIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}