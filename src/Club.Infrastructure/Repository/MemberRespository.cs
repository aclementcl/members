using System;
using Club.Infrastructure.Data;
using Club.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Club.Domain.Interfaces;

namespace Club.Infrastructure.Repository;

public class MemberRespository: IMemberRepository
{
    private readonly ClubContext _context;

    public MemberRespository(ClubContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task<Member?> GetByIdAsync(int id)
    {
        return await _context.Members.FindAsync(id);
    }

    public async Task AddAsync(Member member)
    {
        // await _context.Members.AddAsync(member);
        // await _context.SaveChangesAsync();
    }
}
