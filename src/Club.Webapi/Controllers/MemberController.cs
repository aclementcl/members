using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using Club.Infrastructure.Data;
using Club.Domain.Models;
using Club.Application.Services;

namespace ClubApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly MemberService _memberService;

    public MemberController(MemberService memberService)
    {
        _memberService = memberService;
    }

    // GET: api/member
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
    {
        var members = await _memberService.GetAllMembersAsync();
        return Ok(members);
    }

    // GET: api/member/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Member>> GetMember(int id)
    {
        var member = await _memberService.GetMemberByIdAsync(id);
        if (member == null)
        {
            return NotFound();
        }

        return member;
    }

    // POST: api/member
    [HttpPost]
    public async Task<ActionResult> Create(Member member)
    {
        if (member == null)
        {
            return BadRequest();
        }
        await _memberService.AddMemberAsync(member);
        return Created("User created successfully", member);
        // return CreatedAtAction(nameof(GetMember), new { id = member.Id }, member);
    }

    // PUT: api/member/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMember(int id, Member member)
    {
        if (id != member.Id)
            return BadRequest();

        await _memberService.UpdateMemberAsync(member);
        return NoContent();
    }

    // DELETE: api/member/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _memberService.DeleteMemberAsync(id);
        return NoContent();
    }
}