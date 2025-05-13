using Club.Domain.Models;

namespace Club.Domain.Interfaces;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllMembersAsync();
    Task<Member?> GetByMemberIdAsync(int id);
    Task AddAsync(Member member);
}
