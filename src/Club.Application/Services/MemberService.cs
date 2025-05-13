using System;
using Club.Domain.Interfaces;
using Club.Domain.Models;

namespace Club.Application.Services;

public class MemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
        return await _memberRepository.GetAllMembersAsync();
    }

    public async Task<Member?> GetMemberByIdAsync(int id)
    {
        return await _memberRepository.GetByMemberIdAsync(id);
    }

    public async Task AddMemberAsync(Member member)
    {
        await _memberRepository.AddAsync(member);
    }

    public async Task UpdateMemberAsync(Member member)
    {
        await _memberRepository.UpdateAsync(member);
    }

    public async Task DeleteMemberAsync(int id)
    {
        await _memberRepository.DeleteAsync(id);
    }
}
