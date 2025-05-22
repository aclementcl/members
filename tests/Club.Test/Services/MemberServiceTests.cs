using System;
using Club.Application.Services;
using Club.Domain.Interfaces;
using Club.Domain.Models;
using Moq;

namespace Club.Test;

public class MemberServiceTests
{
    private readonly Mock<IMemberRepository> _mockRepository;
    private readonly MemberService _memberService;

    public MemberServiceTests()
    {
        _mockRepository = new Mock<IMemberRepository>();
        _memberService = new MemberService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllMembersAsync_ReturnsMembers()
    {
        var members = new List<Member>
            {
                new Member { Id = 1, Name = "John" },
                new Member { Id = 2, Name = "Jane" }
            };

        _mockRepository.Setup(repo => repo.GetAllMembersAsync()).ReturnsAsync(members);

        var result = await _memberService.GetAllMembersAsync();

        Assert.Equal(2, result.Count());
    }
}
