using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Club.Infrastructure.Data;

public class ClubContextFactory : IDesignTimeDbContextFactory<ClubContext>
{
    public ClubContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ClubContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ClubAppDb;User Id=sa;Password=Cl4v3Fuerte!; TrustServerCertificate=True;");

        return new ClubContext(optionsBuilder.Options);
    }
}