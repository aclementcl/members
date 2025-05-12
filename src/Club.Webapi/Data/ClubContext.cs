using ClubApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubApp.Data;

public class ClubContext : DbContext
{
    public ClubContext(DbContextOptions<ClubContext> options) : base(options) { }

    public DbSet<Member> Members { get; set; } = null!;
}