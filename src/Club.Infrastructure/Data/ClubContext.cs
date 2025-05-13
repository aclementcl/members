using Club.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Club.Infrastructure.Data;

public class ClubContext : DbContext
{
    public ClubContext(DbContextOptions<ClubContext> options) : base(options) { }

    public DbSet<Member> Members { get; set; } = null!;
}