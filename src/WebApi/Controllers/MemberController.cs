using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClubApp.Data;
using ClubApp.Models;

namespace ClubApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly ClubContext _context;

    public MemberController(ClubContext context)
    {
        _context = context;
    }

    // GET: api/member
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
    {
        return await _context.Members.ToListAsync();
    }

    // GET: api/member/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Member>> GetMember(int id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
        {
            return NotFound();
        }

        return member;
    }

    // POST: api/member
    [HttpPost]
    public async Task<ActionResult<Member>> PostMember(Member member)
    {
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMember), new { id = member.Id }, member);
    }

    // PUT: api/member/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMember(int id, Member member)
    {
        if (id != member.Id)
        {
            return BadRequest();
        }

        _context.Entry(member).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Members.Any(e => e.Id == id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/member/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            return NotFound();
        }

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}